
using System;
using System.Text;

namespace Problem3GenericList
{
	[Version("1.0.0")]
	public class GenericList<T> 
		where T : IComparable<T>
	{
		private const int DefaultCapacitty = 16;
		private T[] array;
		private int index;
		private int currentCapacity;
		
		public GenericList(int capacity = DefaultCapacitty)
		{
			this.CurrentCapacity  = capacity;
			this.array = new T[capacity];
			this.index = 0;	
		}
		
		public int CurrentCapacity
		{
			get { return this.currentCapacity; }
			private set 
			{
				if (value <= 0) 
				{
					throw new ArgumentOutOfRangeException("Capacity should be positive");
				}
				
				this.currentCapacity = value; 
			}
		}
		
		public int Count
		{
			get {return this.index;}			
		}
		
		public T this[int position]
		{
			get
			{
				if (position < 0 || position > this.index)
				{
					throw new IndexOutOfRangeException("Invalid index");
				}
				
				return this.array[position];
			}
			set
			{				
				if (position < 0 || position > this.index)
				{
					throw new IndexOutOfRangeException("Invalid index");
				}
				
				this.array[position] = value;
			}
		}
		
		public void Add(T element)
		{
			this.Insert(element, this.index);
		}	
	
		public void Remove(int ind)
		{
			if (ind < 0 || ind > this.index)
			{
				throw new InvalidOperationException("No such index");
			}
			
			for (int i = ind; i < this.index - 1; i++) 
			{
				this.array[i] = array[i+1];
			}
			
			this.index--;
		}
		
		public int Find(T element)
		{
			for (int i = 0; i < this.index; i++)
			{
				if (this.array[i].Equals(element))
				{
					return i;
				}
			}
			
			return - 1;
		}
		
		public void Clear()
		{
			this.array = new T[this.CurrentCapacity];
			this.index = 0;
		}
		
		private void Resize()
		{
			int newCapacity = this.currentCapacity *2;
			T[] newArray = new T[newCapacity];
			for (int i = 0; i < this.currentCapacity; i++) 
			{
				newArray[i] = this.array[i];
			}
			
			this.array = newArray;
			this.currentCapacity = newCapacity;
		}
		
		public bool Contains(T element)
		{
			for (int i = 0; i < this.index; i++)
			{
				if (array[i].Equals(element)) 
				{
					return true;
				}
			}
			
			return false;
		}
		
		private string Print()
		{
			StringBuilder sb = new StringBuilder();
			
			if (this.index == 0) 
			{
				sb.Append("Generic list is empthy");
			}
			
			bool isFirst = true;
			
			for (int i = 0; i < this.index; i++) 
			{
				if (!isFirst) 
				{
					sb.Append(", ");
				}
				isFirst = false;
				
				sb.Append(array[i]);
			}
			
		return sb.ToString();			
		}
		
		public T Min()
		{
			if (index == 0) 
			{
				throw new InvalidOperationException("Genericlist is empthy");
			}
			
			T min = array[0];
			
			for (int i = 1; i < index; i++)
			{
				if (min.CompareTo(array[i]) > 0) 
				{
					min = array[i];
				}
			}
			
			return min;
		}
		
		public T Max()
		{
			if (index == 0) 
			{
				throw new InvalidOperationException("Genericlist is empthy");
			}
			
			T max = array[0];
			
			for (int i = 1; i < index; i++)
			{
				if (max.CompareTo(array[i]) < 0) 
				{
					max = array[i];
				}
			}
			
			return max;
		}
		
		public void Insert(T element, int position)
		{			
			if (this.index >= this.currentCapacity) 
			{
				Resize();
			}
			
			for (int i = index; i > position; i--)
			{
				array[i] = array[i-1];
			}
			
			array[position] = element;
			this.index++;
		}
		
		
		
		public override string ToString()
		{
			return Print();
		}

	}
}
