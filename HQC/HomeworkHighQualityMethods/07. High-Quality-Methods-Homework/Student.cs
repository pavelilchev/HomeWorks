namespace Methods
{
    using System;

    public class Student
    {
        public Student(string firstName, string lastName, string otherInfo)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.OtherInfo = otherInfo;
        }

        public string FirstName { get; private set; }

        public string LastName { get; set; }

        public string OtherInfo { get;  }

        public bool IsOlderThan(Student other)
        {
            string thisDateToString = this.OtherInfo.Substring(this.OtherInfo.Length - 10);
            string otherDateToString = other.OtherInfo.Substring(other.OtherInfo.Length - 10);

            DateTime firstDate;
            DateTime secondDate;
            bool thisIsparsed = DateTime.TryParse(thisDateToString, out firstDate);
            bool otherIsParsed = DateTime.TryParse(otherDateToString, out secondDate);

            if (!(thisIsparsed && otherIsParsed))
            {
                throw new ArgumentException("Birth Date is not correct.");
            }

            return firstDate < secondDate;
        }
    }
}
