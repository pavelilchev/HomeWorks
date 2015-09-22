
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class ReversedList<T> : IEnumerable
{
    const int DefaultCapacity = 4;

    private T[] data;
    private int count;

    public ReversedList(int capacity = DefaultCapacity)
    {
        this.data = new T[capacity];
        this.count = 0;
    }


    public int Count
    {
        get
        {
            return count;
        }
    }

    public int Capacity
    {
        get
        {
            return this.data.Length;
        }
    }

    public T this[int index]
    {
        get
        {
            if (0 > index || index >= count)
            {
                throw new ArgumentOutOfRangeException();
            }
            return data[index];
        }
        set
        {
            if (0 > index || index >= count)
            {
                throw new ArgumentOutOfRangeException();
            }
            data[index] = value;
        }
    }


    public void Add(T element)
    {
        if (Count >= Capacity)
        {
            ResizeReversedList();
        }

        data[count] = element;
        count++;
    }

    private void ResizeReversedList()
    {
        T[] newData = new T[2 * Capacity];
        data.CopyTo(newData, 0);
        data = newData;
    }

    public void Remove(int index)
    {
        if (index > 0 && index < count)
        {
            Array.Copy(data, index + 1, data, index, count - index);
            count--;
        }
    }

    public Enumerator GetEnumerator()
    {
        return new Enumerator(this);
    }


    IEnumerator IEnumerable.GetEnumerator()
    {
        return new Enumerator(this);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        for (int i = this.Count - 1; i >= 0; i--)
        {
            sb.Append(data[i] + " ");
        }

        return sb.ToString();
    }

    public struct Enumerator : IEnumerator<T>
    {
        private ReversedList<T> list;
        private int index;
        private T current;

        internal Enumerator(ReversedList<T> list)
        {
            this.list = list;
            index = 0;
            current = default(T);
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {

            ReversedList<T> localList = list;

            if (((uint)index < (uint)localList.count))
            {
                current = localList.data[index];
                index++;
                return true;
            }
            return MoveNextRare();
        }

        private bool MoveNextRare()
        {
            index = list.count + 1;
            current = default(T);
            return false;
        }

        public T Current
        {
            get
            {
                return current;
            }
        }

        Object System.Collections.IEnumerator.Current
        {
            get
            {
                if (index == 0 || index == list.count + 1)
                {
                    throw new Exception();
                }
                return Current;
            }
        }

        void System.Collections.IEnumerator.Reset()
        {
            index = 0;
            current = default(T);
        }

    }
}


