
using System;
using System.Collections;
namespace Problem3StringDisperser
{
	public class StringDisperser : IEnumerable, ICloneable, IComparable<StringDisperser>
	{
		private readonly string[] strings;
		
		public StringDisperser(params string[] strings)
		{
			this.strings = strings;
		}
		
		public IEnumerator GetEnumerator()
		{
			string result = this.ToString();
			
			foreach (var ch in result)
			{
				yield return ch;
			}
		}
		
		public override int GetHashCode()
		{
			int hashCode = 0;
			
			if (this.ToString() != null)
			{
				hashCode += 1000000007 * this.ToString().GetHashCode();
			}
			
			return hashCode;
		}

		
		public override bool Equals(object obj)
		{
			StringDisperser other = obj as StringDisperser;
			
			if (other == null)
			{
				return false;
			}
			
			return object.Equals(this.ToString(), other.ToString());
		}
		
		public static bool operator ==(StringDisperser lhs, StringDisperser rhs)
		{
			if (ReferenceEquals(lhs, rhs))
			{
				return true;
			}
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
			{
				return false;
			}
			
			return lhs.Equals(rhs);
		}

		public static bool operator !=(StringDisperser lhs, StringDisperser rhs) {
			return !(lhs == rhs);
		}

		object ICloneable.Clone()
		{
			return this.Clone();
		}
		
		public StringDisperser Clone()
		{
			return new StringDisperser(this.ToString());
		}

		public int CompareTo(StringDisperser other)
		{
			return this.ToString().CompareTo(other.ToString());
		}
		
		public override string ToString()
		{
			return string.Join("", this.strings);
		}
	}
}
