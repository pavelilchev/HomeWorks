
using System;
using System.Collections.Generic;

namespace Problem2Customer
{
	public class Customer : ICloneable, IComparable
	{
		private string firstName;
		private string middleName;
		private string lastname;
		private string id;
		private string permanentAddress;
		private string mobilePhone;
		private string email;
		private readonly IList<Payment> payments;
		
		public Customer(string firstName, string middleName, string lastName, string id, string permanentAddress, string mobilePhone, string email, IList<Payment> payments, CustomerType type)
		{
			this.FirstName = firstName;
			this.MiddleName = middleName;
			this.LastName = lastName;
			this.ID = id;
			this.PermanentAddress = permanentAddress;
			this.MobilePhone = mobilePhone;
			this.Email = email;
			this.payments = payments;
			this.Type = type;
		}
		
		public string FirstName 
			{
			get
			{
				return this.firstName;
			}
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentNullException("Invalid first name");
				}
				
				this.firstName = value;
			}
			
		}
		
		public string MiddleName 
			{
			get
			{
				return this.middleName;
			}
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentNullException("Invalid middle name");
				}
				
				this.middleName = value;
			}
			
		}
		
		public string LastName 
			{
			get
			{
				return this.lastname;
			}
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentNullException("Invalid last name");
				}
				
				this.lastname = value;
			}
			
		}
		
		public string ID 
			{
			get
			{
				return this.id;
			}
			set
			{
				if (string.IsNullOrWhiteSpace(value) || value.Length != 10)
				{
					throw new ArgumentOutOfRangeException("Invalid ID");
				}
				
				this.id = value;
			}
			
		}
		
		public string PermanentAddress 
			{
			get
			{
				return this.permanentAddress;
			}
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentNullException("Invalid address");
				}
				
				this.permanentAddress = value;
			}
			
		}
		
		public string MobilePhone 
			{
			get
			{
				return this.mobilePhone;
			}
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentNullException("Invalid pfone number");
				}
				
				this.mobilePhone = value;
			}
			
		}
		
		public string Email 
			{
			get
			{
				return this.email;
			}
			set
			{
				if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
				{
					throw new ArgumentNullException("Invalid email address");
				}
				
				this.email = value;
			}
			
		}
		
		public IList<Payment> Payments
		{
			get
			{
				return this.payments;
			}
		}
		
		public CustomerType Type {get; set;}
		
		public override bool Equals(object obj)
		{
			Customer other = obj as Customer;
			if (other == null)
			{
				return false;
			}
			return this.ID.Equals(other.ID);
		}
		
		public override int GetHashCode()
		{
			int hashCode =  1000000033 * id.GetHashCode();
			
			return hashCode;
		}

		public static bool operator ==(Customer lhs, Customer rhs) 
		{
			if (ReferenceEquals(lhs, rhs))
				return true;
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
				return false;
			return lhs.Equals(rhs);
		}

		public static bool operator !=(Customer lhs, Customer rhs) 
		{
			return !(lhs == rhs);
		}
		
	    object ICloneable.Clone()
		{
			return this.Clone();
		}
		
		public Customer Clone()
		{
			List<Payment> paymentsCopy = new List<Payment>();
			
			foreach (var payment in this.Payments)
			{
				var productNameCopy = payment.ProductName;
				var priceCopy = payment.Price;
				
				var paymentCopy = new Payment(productNameCopy, priceCopy);
				paymentsCopy.Add(paymentCopy);
			}
			
			Customer copy = new Customer(this.FirstName, this.MiddleName, this.LastName, this.ID, this.PermanentAddress, this.MobilePhone, 
			                             this.Email, paymentsCopy, this.Type);
			return copy;
		}

		public int CompareTo(object obj)
		{
			Customer other = obj as Customer;
			string fullName = this.FirstName + " " + this.MiddleName + " " + this.LastName;
			string otherFullName = other.FirstName + " " + other.MiddleName + " " + other.LastName;
			if (fullName != otherFullName)
			{
				return fullName.CompareTo(otherFullName);
			}
			
			if (this.ID != other.ID) 
			{
				return this.ID.CompareTo(other.ID);
			}
			
			return 0;
		}
		
		public override string ToString()
		{
			string pay = string.Join(", ", this.Payments);
			return string.Format("[Customer Name: {0} {1} {2}, Id: {3}, Address: {4}, Mobilephone: {5}, Email: {6}, Payments: {7}, Type={8}]", this.FirstName, this.MiddleName, this.LastName, this.ID, this.PermanentAddress, this.MobilePhone, this.Email, pay, this.Type);
		}

	}
}
