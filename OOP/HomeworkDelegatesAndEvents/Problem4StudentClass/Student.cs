using System.ComponentModel;

namespace Problem4StudentClass
{
    public class Student
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string name;
        private int age;

        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get
            {
                return this.name;
                
            }
            set
            {
                PropertyChangedEventArgs args = new PropertyChangedEventArgs("Name", this.Name, value);
                var onPropetyChanged = this.PropertyChanged;
                if (onPropetyChanged != null)
                {
                    onPropetyChanged(this, args);
                }

                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
                
            }
            set
            {
                PropertyChangedEventArgs args = new PropertyChangedEventArgs("Age", this.Age, value);
                var onPropetyChanged = this.PropertyChanged;

                if (onPropetyChanged != null)
                {
                    onPropetyChanged(this, args);
                }

                this.age = value;
            }
        }
    }
}
