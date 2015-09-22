
//namespace System.Collections.Generic
//{

//    using System;
//    using Diagnostics.Contracts;
//    using ObjectModel;

//    public class List<T> : IList<T>, System.Collections.IList, IReadOnlyList<T>
//    {
//        private const int _defaultCapacity = 4;

//        private T[] data;
//        [ContractPublicPropertyName("Count")]
//        private int count;
//        private int _version;
//        [NonSerialized]
//        private Object _syncRoot;

//        static readonly T[] _emptyArray = new T[0];

//        // Constructs a List. The list is initially empty and has a capacity
//        // of zero. Upon adding the first element to the list the capacity is
//        // increased to 16, and then increased in multiples of two as required.
//        public List()
//        {
//            data = _emptyArray;
//        }

//        // Constructs a List with a given initial capacity. The list is
//        // initially empty, but will have room for the given number of elements
//        // before any reallocations are required.
//        // 
//        public List(int capacity)
//        {
//            if (capacity < 0)
//            {
//                throw new ArgumentOutOfRangeException();
//            }

//            if (capacity == 0)
//                data = _emptyArray;

//            else
//                data = new T[capacity];
//        }

//        // Constructs a List, copying the contents of the given collection. The
//        // size and capacity of the new list will both be equal to the size of the
//        // given collection.
//        // 
//        public List(IEnumerable<T> collection)
//        {
//            if (collection == null)
//                throw new ArgumentOutOfRangeException();
//            Contract.EndContractBlock();

//            ICollection<T> c = collection as ICollection<T>;
//            if (c != null)
//            {
//                int count = c.Count;
//                if (count == 0)
//                {
//                    data = _emptyArray;
//                }
//                else
//                {
//                    data = new T[count];
//                    c.CopyTo(data, 0);
//                    this.count = count;
//                }
//            }
//            else
//            {
//                count = 0;
//                data = _emptyArray;
//                // This enumerable could be empty.  Let Add allocate a new array, if needed.
//                // Note it will also go to _defaultCapacity first, not 1, then 2, etc.

//                using (IEnumerator<T> en = collection.GetEnumerator())
//                {
//                    while (en.MoveNext())
//                    {
//                        Add(en.Current);
//                    }
//                }
//            }
//        }

//        // Gets and sets the capacity of this list.  The capacity is the size of
//        // the internal array used to hold items.  When set, the internal 
//        // array of the list is reallocated to the given capacity.
//        // 
//        public int Capacity
//        {
//            get
//            {
//                Contract.Ensures(Contract.Result<int>() >= 0);
//                return data.Length;
//            }
//            set
//            {
//                if (value < count)
//                {
//                    throw new ArgumentOutOfRangeException();
//                }
//                Contract.EndContractBlock();

//                if (value != data.Length)
//                {
//                    if (value > 0)
//                    {
//                        T[] newItems = new T[value];
//                        if (count > 0)
//                        {
//                            Array.Copy(data, 0, newItems, 0, count);
//                        }
//                        data = newItems;
//                    }
//                    else
//                    {
//                        data = _emptyArray;
//                    }
//                }
//            }
//        }

//        // Read-only property describing how many elements are in the List.
//        public int Count
//        {
//            get
//            {
//                Contract.Ensures(Contract.Result<int>() >= 0);
//                return count;
//            }
//        }

//        bool System.Collections.IList.IsFixedSize
//        {
//            get { return false; }
//        }


//        // Is this List read-only?
//        bool ICollection<T>.IsReadOnly
//        {
//            get { return false; }
//        }

//        bool System.Collections.IList.IsReadOnly
//        {
//            get { return false; }
//        }

//        // Is this List synchronized (thread-safe)?
//        bool System.Collections.ICollection.IsSynchronized
//        {
//            get { return false; }
//        }

//        // Synchronization root for this object.
//        Object System.Collections.ICollection.SyncRoot
//        {
//            get
//            {
//                if (_syncRoot == null)
//                {
//                    System.Threading.Interlocked.CompareExchange<Object>(ref _syncRoot, new Object(), null);
//                }
//                return _syncRoot;
//            }
//        }
//        // Sets or Gets the element at the given index.
//        // 
//        public T this[int index]
//        {
//            get
//            {
//                // Following trick can reduce the range check by one
//                if ((uint)index >= (uint)count)
//                {
//                    throw new ArgumentOutOfRangeException();
//                }
//                Contract.EndContractBlock();
//                return data[index];
//            }

//            set
//            {
//                if ((uint)index >= (uint)count)
//                {
//                    throw new ArgumentOutOfRangeException();
//                }
//                Contract.EndContractBlock();
//                data[index] = value;
//                _version++;
//            }
//        }

//        private static bool IsCompatibleObject(object value)
//        {
//            // Non-null values are fine.  Only accept nulls if T is a class or Nullable<U>.
//            // Note that default(T) is not equal to null for value types except when T is Nullable<U>. 
//            return ((value is T) || (value == null && default(T) == null));
//        }

//        Object System.Collections.IList.this[int index]
//        {
//            get
//            {
//                return this[index];
//            }
//            set
//            {
//                throw new ArgumentOutOfRangeException();


//                try
//                {
//                    this[index] = (T)value;
//                }
//                catch (InvalidCastException)
//                {
//                    throw new ArgumentOutOfRangeException();

//                }
//            }
//        }

//        // Adds the given object to the end of this list. The size of the list is
//        // increased by one. If required, the capacity of the list is doubled
//        // before adding the new element.
//        //
//        public void Add(T item)
//        {
//            if (count == data.Length) EnsureCapacity(count + 1);
//            data[count++] = item;
//            _version++;
//        }

//        int System.Collections.IList.Add(Object item)
//        {
//            throw new ArgumentOutOfRangeException();


//            try
//            {
//                Add((T)item);
//            }
//            catch (InvalidCastException)
//            {
//                throw new ArgumentOutOfRangeException();

//            }

//            return Count - 1;
//        }


//        // Adds the elements of the given collection to the end of this list. If
//        // required, the capacity of the list is increased to twice the previous
//        // capacity or the new size, whichever is larger.
//        //
//        public void AddRange(IEnumerable<T> collection)
//        {
//            Contract.Ensures(Count >= Contract.OldValue(Count));

//            InsertRange(count, collection);
//        }

//        public ReadOnlyCollection<T> AsReadOnly()
//        {
//            Contract.Ensures(Contract.Result<ReadOnlyCollection<T>>() != null);
//            return new ReadOnlyCollection<T>(this);
//        }

//        // Searches a section of the list for a given element using a binary search
//        // algorithm. Elements of the list are compared to the search value using
//        // the given IComparer interface. If comparer is null, elements of
//        // the list are compared to the search value using the IComparable
//        // interface, which in that case must be implemented by all elements of the
//        // list and the given search value. This method assumes that the given
//        // section of the list is already sorted; if this is not the case, the
//        // result will be incorrect.
//        //
//        // The method returns the index of the given value in the list. If the
//        // list does not contain the given value, the method returns a negative
//        // integer. The bitwise complement operator (~) can be applied to a
//        // negative result to produce the index of the first element (if any) that
//        // is larger than the given search value. This is also the index at which
//        // the search value should be inserted into the list in order for the list
//        // to remain sorted.
//        // 
//        // The method uses the Array.BinarySearch method to perform the
//        // search.
//        // 
//        public int BinarySearch(int index, int count, T item, IComparer<T> comparer)
//        {
//            if (index < 0)
//                throw new ArgumentOutOfRangeException();

//            if (count < 0)
//                throw new ArgumentOutOfRangeException();

//            if (this.count - index < count)
//                throw new ArgumentOutOfRangeException();

//            Contract.Ensures(Contract.Result<int>() <= index + count);
//            Contract.EndContractBlock();

//            return Array.BinarySearch<T>(data, index, count, item, comparer);
//        }

//        public int BinarySearch(T item)
//        {
//            Contract.Ensures(Contract.Result<int>() <= Count);
//            return BinarySearch(0, Count, item, null);
//        }

//        public int BinarySearch(T item, IComparer<T> comparer)
//        {
//            Contract.Ensures(Contract.Result<int>() <= Count);
//            return BinarySearch(0, Count, item, comparer);
//        }


//        // Clears the contents of List.
//        public void Clear()
//        {
//            if (count > 0)
//            {
//                Array.Clear(data, 0, count); // Don't need to doc this but we clear the elements so that the gc can reclaim the references.
//                count = 0;
//            }
//            _version++;
//        }

//        // Contains returns true if the specified element is in the List.
//        // It does a linear, O(n) search.  Equality is determined by calling
//        // item.Equals().
//        //
//        public bool Contains(T item)
//        {
//            if ((Object)item == null)
//            {
//                for (int i = 0; i < count; i++)
//                    if ((Object)data[i] == null)
//                        return true;
//                return false;
//            }
//            else
//            {
//                EqualityComparer<T> c = EqualityComparer<T>.Default;
//                for (int i = 0; i < count; i++)
//                {
//                    if (c.Equals(data[i], item)) return true;
//                }
//                return false;
//            }
//        }

//        bool System.Collections.IList.Contains(Object item)
//        {
//            if (IsCompatibleObject(item))
//            {
//                return Contains((T)item);
//            }
//            return false;
//        }

//        public List<TOutput> ConvertAll<TOutput>(Converter<T, TOutput> converter)
//        {
//            if (converter == null)
//            {
//                throw new ArgumentOutOfRangeException();

//            }
//            // @


//            Contract.EndContractBlock();

//            List<TOutput> list = new List<TOutput>(count);
//            for (int i = 0; i < count; i++)
//            {
//                list.data[i] = converter(data[i]);
//            }
//            list.count = count;
//            return list;
//        }

//        // Copies this List into array, which must be of a 
//        // compatible array type.  
//        //
//        public void CopyTo(T[] array)
//        {
//            CopyTo(array, 0);
//        }

//        // Copies this List into array, which must be of a 
//        // compatible array type.  
//        //
//        void System.Collections.ICollection.CopyTo(Array array, int arrayIndex)
//        {
//            if ((array != null) && (array.Rank != 1))
//            {
//                ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_RankMultiDimNotSupported);
//            }
//            Contract.EndContractBlock();

//            try
//            {
//                // Array.Copy will check for NULL.
//                Array.Copy(data, 0, array, arrayIndex, count);
//            }
//            catch (ArrayTypeMismatchException)
//            {
//                ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidArrayType);
//            }
//        }

//        // Copies a section of this list to the given array at the given index.
//        // 
//        // The method uses the Array.Copy method to copy the elements.
//        // 
//        public void CopyTo(int index, T[] array, int arrayIndex, int count)
//        {
//            if (this.count - index < count)
//            {
//                ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidOffLen);
//            }
//            Contract.EndContractBlock();

//            // Delegate rest of error checking to Array.Copy.
//            Array.Copy(data, index, array, arrayIndex, count);
//        }

//        public void CopyTo(T[] array, int arrayIndex)
//        {
//            // Delegate rest of error checking to Array.Copy.
//            Array.Copy(data, 0, array, arrayIndex, count);
//        }

//        // Ensures that the capacity of this list is at least the given minimum
//        // value. If the currect capacity of the list is less than min, the
//        // capacity is increased to twice the current capacity or to min,
//        // whichever is larger.
//        private void EnsureCapacity(int min)
//        {
//            if (data.Length < min)
//            {
//                int newCapacity = data.Length == 0 ? _defaultCapacity : data.Length * 2;
//                // Allow the list to grow to maximum possible capacity (~2G elements) before encountering overflow.
//                // Note that this check works even when _items.Length overflowed thanks to the (uint) cast
//                if ((uint)newCapacity > Array.MaxArrayLength) newCapacity = Array.MaxArrayLength;
//                if (newCapacity < min) newCapacity = min;
//                Capacity = newCapacity;
//            }
//        }

//        public bool Exists(Predicate<T> match)
//        {
//            return FindIndex(match) != -1;
//        }

//        public T Find(Predicate<T> match)
//        {
//            if (match == null)
//            {
//                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.match);
//            }
//            Contract.EndContractBlock();

//            for (int i = 0; i < count; i++)
//            {
//                if (match(data[i]))
//                {
//                    return data[i];
//                }
//            }
//            return default(T);
//        }

//        public List<T> FindAll(Predicate<T> match)
//        {
//            if (match == null)
//            {
//                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.match);
//            }
//            Contract.EndContractBlock();

//            List<T> list = new List<T>();
//            for (int i = 0; i < count; i++)
//            {
//                if (match(data[i]))
//                {
//                    list.Add(data[i]);
//                }
//            }
//            return list;
//        }

//        public int FindIndex(Predicate<T> match)
//        {
//            Contract.Ensures(Contract.Result<int>() >= -1);
//            Contract.Ensures(Contract.Result<int>() < Count);
//            return FindIndex(0, count, match);
//        }

//        public int FindIndex(int startIndex, Predicate<T> match)
//        {
//            Contract.Ensures(Contract.Result<int>() >= -1);
//            Contract.Ensures(Contract.Result<int>() < startIndex + Count);
//            return FindIndex(startIndex, count - startIndex, match);
//        }

//        public int FindIndex(int startIndex, int count, Predicate<T> match)
//        {
//            if ((uint)startIndex > (uint)this.count)
//            {
//                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.startIndex, ExceptionResource.ArgumentOutOfRange_Index);
//            }

//            if (count < 0 || startIndex > this.count - count)
//            {
//                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.count, ExceptionResource.ArgumentOutOfRange_Count);
//            }

//            if (match == null)
//            {
//                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.match);
//            }
//            Contract.Ensures(Contract.Result<int>() >= -1);
//            Contract.Ensures(Contract.Result<int>() < startIndex + count);
//            Contract.EndContractBlock();

//            int endIndex = startIndex + count;
//            for (int i = startIndex; i < endIndex; i++)
//            {
//                if (match(data[i])) return i;
//            }
//            return -1;
//        }

//        public T FindLast(Predicate<T> match)
//        {
//            if (match == null)
//            {
//                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.match);
//            }
//            Contract.EndContractBlock();

//            for (int i = count - 1; i >= 0; i--)
//            {
//                if (match(data[i]))
//                {
//                    return data[i];
//                }
//            }
//            return default(T);
//        }

//        public int FindLastIndex(Predicate<T> match)
//        {
//            Contract.Ensures(Contract.Result<int>() >= -1);
//            Contract.Ensures(Contract.Result<int>() < Count);
//            return FindLastIndex(count - 1, count, match);
//        }

//        public int FindLastIndex(int startIndex, Predicate<T> match)
//        {
//            Contract.Ensures(Contract.Result<int>() >= -1);
//            Contract.Ensures(Contract.Result<int>() <= startIndex);
//            return FindLastIndex(startIndex, startIndex + 1, match);
//        }

//        public int FindLastIndex(int startIndex, int count, Predicate<T> match)
//        {
//            if (match == null)
//            {
//                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.match);
//            }
//            Contract.Ensures(Contract.Result<int>() >= -1);
//            Contract.Ensures(Contract.Result<int>() <= startIndex);
//            Contract.EndContractBlock();

//            if (this.count == 0)
//            {
//                // Special case for 0 length List
//                if (startIndex != -1)
//                {
//                    ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.startIndex, ExceptionResource.ArgumentOutOfRange_Index);
//                }
//            }
//            else
//            {
//                // Make sure we're not out of range            
//                if ((uint)startIndex >= (uint)this.count)
//                {
//                    ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.startIndex, ExceptionResource.ArgumentOutOfRange_Index);
//                }
//            }

//            // 2nd have of this also catches when startIndex == MAXINT, so MAXINT - 0 + 1 == -1, which is < 0.
//            if (count < 0 || startIndex - count + 1 < 0)
//            {
//                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.count, ExceptionResource.ArgumentOutOfRange_Count);
//            }

//            int endIndex = startIndex - count;
//            for (int i = startIndex; i > endIndex; i--)
//            {
//                if (match(data[i]))
//                {
//                    return i;
//                }
//            }
//            return -1;
//        }

//        public void ForEach(Action<T> action)
//        {
//            if (action == null)
//            {
//                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.match);
//            }
//            Contract.EndContractBlock();

//            int version = _version;

//            for (int i = 0; i < count; i++)
//            {
//                if (version != _version && BinaryCompatibility.TargetsAtLeast_Desktop_V4_5)
//                {
//                    break;
//                }
//                action(data[i]);
//            }

//            if (version != _version && BinaryCompatibility.TargetsAtLeast_Desktop_V4_5)
//                ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_EnumFailedVersion);
//        }

//        // Returns an enumerator for this list with the given
//        // permission for removal of elements. If modifications made to the list 
//        // while an enumeration is in progress, the MoveNext and 
//        // GetObject methods of the enumerator will throw an exception.
//        //
//        public Enumerator GetEnumerator()
//        {
//            return new Enumerator(this);
//        }

//        /// <internalonly/>
//        IEnumerator<T> IEnumerable<T>.GetEnumerator()
//        {
//            return new Enumerator(this);
//        }

//        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
//        {
//            return new Enumerator(this);
//        }

//        public List<T> GetRange(int index, int count)
//        {
//            if (index < 0)
//            {
//                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
//            }

//            if (count < 0)
//            {
//                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.count, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
//            }

//            if (this.count - index < count)
//            {
//                ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidOffLen);
//            }
//            Contract.Ensures(Contract.Result<List<T>>() != null);
//            Contract.EndContractBlock();

//            List<T> list = new List<T>(count);
//            Array.Copy(data, index, list.data, 0, count);
//            list.count = count;
//            return list;
//        }


//        // Returns the index of the first occurrence of a given value in a range of
//        // this list. The list is searched forwards from beginning to end.
//        // The elements of the list are compared to the given value using the
//        // Object.Equals method.
//        // 
//        // This method uses the Array.IndexOf method to perform the
//        // search.
//        // 
//        public int IndexOf(T item)
//        {
//            Contract.Ensures(Contract.Result<int>() >= -1);
//            Contract.Ensures(Contract.Result<int>() < Count);
//            return Array.IndexOf(data, item, 0, count);
//        }

//        int System.Collections.IList.IndexOf(Object item)
//        {
//            if (IsCompatibleObject(item))
//            {
//                return IndexOf((T)item);
//            }
//            return -1;
//        }

//        // Returns the index of the first occurrence of a given value in a range of
//        // this list. The list is searched forwards, starting at index
//        // index and ending at count number of elements. The
//        // elements of the list are compared to the given value using the
//        // Object.Equals method.
//        // 
//        // This method uses the Array.IndexOf method to perform the
//        // search.
//        // 
//        public int IndexOf(T item, int index)
//        {
//            if (index > count)
//                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_Index);
//            Contract.Ensures(Contract.Result<int>() >= -1);
//            Contract.Ensures(Contract.Result<int>() < Count);
//            Contract.EndContractBlock();
//            return Array.IndexOf(data, item, index, count - index);
//        }

//        // Returns the index of the first occurrence of a given value in a range of
//        // this list. The list is searched forwards, starting at index
//        // index and upto count number of elements. The
//        // elements of the list are compared to the given value using the
//        // Object.Equals method.
//        // 
//        // This method uses the Array.IndexOf method to perform the
//        // search.
//        // 
//        public int IndexOf(T item, int index, int count)
//        {
//            if (index > this.count)
//                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_Index);

//            if (count < 0 || index > this.count - count) ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.count, ExceptionResource.ArgumentOutOfRange_Count);
//            Contract.Ensures(Contract.Result<int>() >= -1);
//            Contract.Ensures(Contract.Result<int>() < Count);
//            Contract.EndContractBlock();

//            return Array.IndexOf(data, item, index, count);
//        }

//        // Inserts an element into this list at a given index. The size of the list
//        // is increased by one. If required, the capacity of the list is doubled
//        // before inserting the new element.
//        // 
//        public void Insert(int index, T item)
//        {
//            // Note that insertions at the end are legal.
//            if ((uint)index > (uint)count)
//            {
//                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_ListInsert);
//            }
//            Contract.EndContractBlock();
//            if (count == data.Length) EnsureCapacity(count + 1);
//            if (index < count)
//            {
//                Array.Copy(data, index, data, index + 1, count - index);
//            }
//            data[index] = item;
//            count++;
//            _version++;
//        }

//        void System.Collections.IList.Insert(int index, Object item)
//        {
//            ThrowHelper.IfNullAndNullsAreIllegalThenThrow<T>(item, ExceptionArgument.item);

//            try
//            {
//                Insert(index, (T)item);
//            }
//            catch (InvalidCastException)
//            {
//                ThrowHelper.ThrowWrongValueTypeArgumentException(item, typeof(T));
//            }
//        }

//        // Inserts the elements of the given collection at a given index. If
//        // required, the capacity of the list is increased to twice the previous
//        // capacity or the new size, whichever is larger.  Ranges may be added
//        // to the end of the list by setting index to the List's size.
//        //
//        public void InsertRange(int index, IEnumerable<T> collection)
//        {
//            if (collection == null)
//            {
//                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.collection);
//            }

//            if ((uint)index > (uint)count)
//            {
//                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_Index);
//            }
//            Contract.EndContractBlock();

//            ICollection<T> c = collection as ICollection<T>;
//            if (c != null)
//            {    // if collection is ICollection<T>
//                int count = c.Count;
//                if (count > 0)
//                {
//                    EnsureCapacity(this.count + count);
//                    if (index < this.count)
//                    {
//                        Array.Copy(data, index, data, index + count, this.count - index);
//                    }

//                    // If we're inserting a List into itself, we want to be able to deal with that.
//                    if (this == c)
//                    {
//                        // Copy first part of _items to insert location
//                        Array.Copy(data, 0, data, index, index);
//                        // Copy last part of _items back to inserted location
//                        Array.Copy(data, index + count, data, index * 2, this.count - index);
//                    }
//                    else
//                    {
//                        T[] itemsToInsert = new T[count];
//                        c.CopyTo(itemsToInsert, 0);
//                        itemsToInsert.CopyTo(data, index);
//                    }
//                    this.count += count;
//                }
//            }
//            else
//            {
//                using (IEnumerator<T> en = collection.GetEnumerator())
//                {
//                    while (en.MoveNext())
//                    {
//                        Insert(index++, en.Current);
//                    }
//                }
//            }
//            _version++;
//        }

//        // Returns the index of the last occurrence of a given value in a range of
//        // this list. The list is searched backwards, starting at the end 
//        // and ending at the first element in the list. The elements of the list 
//        // are compared to the given value using the Object.Equals method.
//        // 
//        // This method uses the Array.LastIndexOf method to perform the
//        // search.
//        // 
//        public int LastIndexOf(T item)
//        {
//            Contract.Ensures(Contract.Result<int>() >= -1);
//            Contract.Ensures(Contract.Result<int>() < Count);
//            if (count == 0)
//            {  // Special case for empty list
//                return -1;
//            }
//            else
//            {
//                return LastIndexOf(item, count - 1, count);
//            }
//        }

//        // Returns the index of the last occurrence of a given value in a range of
//        // this list. The list is searched backwards, starting at index
//        // index and ending at the first element in the list. The 
//        // elements of the list are compared to the given value using the 
//        // Object.Equals method.
//        // 
//        // This method uses the Array.LastIndexOf method to perform the
//        // search.
//        // 
//        public int LastIndexOf(T item, int index)
//        {
//            if (index >= count)
//                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_Index);
//            Contract.Ensures(Contract.Result<int>() >= -1);
//            Contract.Ensures(((Count == 0) && (Contract.Result<int>() == -1)) || ((Count > 0) && (Contract.Result<int>() <= index)));
//            Contract.EndContractBlock();
//            return LastIndexOf(item, index, index + 1);
//        }

//        // Returns the index of the last occurrence of a given value in a range of
//        // this list. The list is searched backwards, starting at index
//        // index and upto count elements. The elements of
//        // the list are compared to the given value using the Object.Equals
//        // method.
//        // 
//        // This method uses the Array.LastIndexOf method to perform the
//        // search.
//        // 
//        public int LastIndexOf(T item, int index, int count)
//        {
//            if ((Count != 0) && (index < 0))
//            {
//                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
//            }

//            if ((Count != 0) && (count < 0))
//            {
//                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.count, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
//            }
//            Contract.Ensures(Contract.Result<int>() >= -1);
//            Contract.Ensures(((Count == 0) && (Contract.Result<int>() == -1)) || ((Count > 0) && (Contract.Result<int>() <= index)));
//            Contract.EndContractBlock();

//            if (this.count == 0)
//            {  // Special case for empty list
//                return -1;
//            }

//            if (index >= this.count)
//            {
//                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_BiggerThanCollection);
//            }

//            if (count > index + 1)
//            {
//                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.count, ExceptionResource.ArgumentOutOfRange_BiggerThanCollection);
//            }

//            return Array.LastIndexOf(data, item, index, count);
//        }

//        // Removes the element at the given index. The size of the list is
//        // decreased by one.
//        // 
//        public bool Remove(T item)
//        {
//            int index = IndexOf(item);
//            if (index >= 0)
//            {
//                RemoveAt(index);
//                return true;
//            }

//            return false;
//        }

//        void System.Collections.IList.Remove(Object item)
//        {
//            if (IsCompatibleObject(item))
//            {
//                Remove((T)item);
//            }
//        }

//        // This method removes all items which matches the predicate.
//        // The complexity is O(n).   
//        public int RemoveAll(Predicate<T> match)
//        {
//            if (match == null)
//            {
//                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.match);
//            }
//            Contract.Ensures(Contract.Result<int>() >= 0);
//            Contract.Ensures(Contract.Result<int>() <= Contract.OldValue(Count));
//            Contract.EndContractBlock();

//            int freeIndex = 0;   // the first free slot in items array

//            // Find the first item which needs to be removed.
//            while (freeIndex < count && !match(data[freeIndex])) freeIndex++;
//            if (freeIndex >= count) return 0;

//            int current = freeIndex + 1;
//            while (current < count)
//            {
//                // Find the first item which needs to be kept.
//                while (current < count && match(data[current])) current++;

//                if (current < count)
//                {
//                    // copy item to the free slot.
//                    data[freeIndex++] = data[current++];
//                }
//            }

//            Array.Clear(data, freeIndex, count - freeIndex);
//            int result = count - freeIndex;
//            count = freeIndex;
//            _version++;
//            return result;
//        }

//        // Removes the element at the given index. The size of the list is
//        // decreased by one.
//        // 
//        public void RemoveAt(int index)
//        {
//            if ((uint)index >= (uint)count)
//            {
//                ThrowHelper.ThrowArgumentOutOfRangeException();
//            }
//            Contract.EndContractBlock();
//            count--;
//            if (index < count)
//            {
//                Array.Copy(data, index + 1, data, index, count - index);
//            }
//            data[count] = default(T);
//            _version++;
//        }

//        // Removes a range of elements from this list.
//        // 
//        public void RemoveRange(int index, int count)
//        {
//            if (index < 0)
//            {
//                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
//            }

//            if (count < 0)
//            {
//                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.count, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
//            }

//            if (this.count - index < count)
//                ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidOffLen);
//            Contract.EndContractBlock();

//            if (count > 0)
//            {
//                int i = this.count;
//                this.count -= count;
//                if (index < this.count)
//                {
//                    Array.Copy(data, index + count, data, index, this.count - index);
//                }
//                Array.Clear(data, this.count, count);
//                _version++;
//            }
//        }

//        // Reverses the elements in this list.
//        public void Reverse()
//        {
//            Reverse(0, Count);
//        }

//        // Reverses the elements in a range of this list. Following a call to this
//        // method, an element in the range given by index and count
//        // which was previously located at index i will now be located at
//        // index index + (index + count - i - 1).
//        // 
//        // This method uses the Array.Reverse method to reverse the
//        // elements.
//        // 
//        public void Reverse(int index, int count)
//        {
//            if (index < 0)
//            {
//                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
//            }

//            if (count < 0)
//            {
//                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.count, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
//            }

//            if (this.count - index < count)
//                ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidOffLen);
//            Contract.EndContractBlock();
//            Array.Reverse(data, index, count);
//            _version++;
//        }

//        // Sorts the elements in this list.  Uses the default comparer and 
//        // Array.Sort.
//        public void Sort()
//        {
//            Sort(0, Count, null);
//        }

//        // Sorts the elements in this list.  Uses Array.Sort with the
//        // provided comparer.
//        public void Sort(IComparer<T> comparer)
//        {
//            Sort(0, Count, comparer);
//        }

//        // Sorts the elements in a section of this list. The sort compares the
//        // elements to each other using the given IComparer interface. If
//        // comparer is null, the elements are compared to each other using
//        // the IComparable interface, which in that case must be implemented by all
//        // elements of the list.
//        // 
//        // This method uses the Array.Sort method to sort the elements.
//        // 
//        public void Sort(int index, int count, IComparer<T> comparer)
//        {
//            if (index < 0)
//            {
//                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
//            }

//            if (count < 0)
//            {
//                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.count, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
//            }

//            if (this.count - index < count)
//                ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidOffLen);
//            Contract.EndContractBlock();

//            Array.Sort<T>(data, index, count, comparer);
//            _version++;
//        }

//        public void Sort(Comparison<T> comparison)
//        {
//            if (comparison == null)
//            {
//                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.match);
//            }
//            Contract.EndContractBlock();

//            if (count > 0)
//            {
//                IComparer<T> comparer = new Array.FunctorComparer<T>(comparison);
//                Array.Sort(data, 0, count, comparer);
//            }
//        }

//        // ToArray returns a new Object array containing the contents of the List.
//        // This requires copying the List, which is an O(n) operation.
//        public T[] ToArray()
//        {
//            Contract.Ensures(Contract.Result<T[]>() != null);
//            Contract.Ensures(Contract.Result<T[]>().Length == Count);

//            T[] array = new T[count];
//            Array.Copy(data, 0, array, 0, count);
//            return array;
//        }

//        // Sets the capacity of this list to the size of the list. This method can
//        // be used to minimize a list's memory overhead once it is known that no
//        // new elements will be added to the list. To completely clear a list and
//        // release all memory referenced by the list, execute the following
//        // statements:
//        // 
//        // list.Clear();
//        // list.TrimExcess();
//        // 
//        public void TrimExcess()
//        {
//            int threshold = (int)(((double)data.Length) * 0.9);
//            if (count < threshold)
//            {
//                Capacity = count;
//            }
//        }

//        public bool TrueForAll(Predicate<T> match)
//        {
//            if (match == null)
//            {
//                ThrowHelper.ThrowArgumentNullException(ExceptionArgument.match);
//            }
//            Contract.EndContractBlock();

//            for (int i = 0; i < count; i++)
//            {
//                if (!match(data[i]))
//                {
//                    return false;
//                }
//            }
//            return true;
//        }

//        internal static IList<T> Synchronized(List<T> list)
//        {
//            return new SynchronizedList(list);
//        }

//        [Serializable()]
//        internal class SynchronizedList : IList<T>
//        {
//            private List<T> _list;
//            private Object _root;

//            internal SynchronizedList(List<T> list)
//            {
//                _list = list;
//                _root = ((System.Collections.ICollection)list).SyncRoot;
//            }

//            public int Count
//            {
//                get
//                {
//                    lock (_root)
//                    {
//                        return _list.Count;
//                    }
//                }
//            }

//            public bool IsReadOnly
//            {
//                get
//                {
//                    return ((ICollection<T>)_list).IsReadOnly;
//                }
//            }

//            public void Add(T item)
//            {
//                lock (_root)
//                {
//                    _list.Add(item);
//                }
//            }

//            public void Clear()
//            {
//                lock (_root)
//                {
//                    _list.Clear();
//                }
//            }

//            public bool Contains(T item)
//            {
//                lock (_root)
//                {
//                    return _list.Contains(item);
//                }
//            }

//            public void CopyTo(T[] array, int arrayIndex)
//            {
//                lock (_root)
//                {
//                    _list.CopyTo(array, arrayIndex);
//                }
//            }

//            public bool Remove(T item)
//            {
//                lock (_root)
//                {
//                    return _list.Remove(item);
//                }
//            }

//            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
//            {
//                lock (_root)
//                {
//                    return _list.GetEnumerator();
//                }
//            }

//            IEnumerator<T> IEnumerable<T>.GetEnumerator()
//            {
//                lock (_root)
//                {
//                    return ((IEnumerable<T>)_list).GetEnumerator();
//                }
//            }

//            public T this[int index]
//            {
//                get
//                {
//                    lock (_root)
//                    {
//                        return _list[index];
//                    }
//                }
//                set
//                {
//                    lock (_root)
//                    {
//                        _list[index] = value;
//                    }
//                }
//            }

//            public int IndexOf(T item)
//            {
//                lock (_root)
//                {
//                    return _list.IndexOf(item);
//                }
//            }

//            public void Insert(int index, T item)
//            {
//                lock (_root)
//                {
//                    _list.Insert(index, item);
//                }
//            }

//            public void RemoveAt(int index)
//            {
//                lock (_root)
//                {
//                    _list.RemoveAt(index);
//                }
//            }
//        }

//        [Serializable]
//        public struct Enumerator : IEnumerator<T>, System.Collections.IEnumerator
//        {
//            private List<T> list;
//            private int index;
//            private int version;
//            private T current;

//            internal Enumerator(List<T> list)
//            {
//                this.list = list;
//                index = 0;
//                version = list._version;
//                current = default(T);
//            }

//            public void Dispose()
//            {
//            }

//            public bool MoveNext()
//            {

//                List<T> localList = list;

//                if (version == localList._version && ((uint)index < (uint)localList.count))
//                {
//                    current = localList.data[index];
//                    index++;
//                    return true;
//                }
//                return MoveNextRare();
//            }

//            private bool MoveNextRare()
//            {
//                if (version != list._version)
//                {
//                    ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_EnumFailedVersion);
//                }

//                index = list.count + 1;
//                current = default(T);
//                return false;
//            }

//            public T Current
//            {
//                get
//                {
//                    return current;
//                }
//            }

//            Object System.Collections.IEnumerator.Current
//            {
//                get
//                {
//                    if (index == 0 || index == list.count + 1)
//                    {
//                        ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_EnumOpCantHappen);
//                    }
//                    return Current;
//                }
//            }

//            void System.Collections.IEnumerator.Reset()
//            {
//                if (version != list._version)
//                {
//                    ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_EnumFailedVersion);
//                }

//                index = 0;
//                current = default(T);
//            }

//        }
//    }
//}



