﻿namespace _1.DefineClassPerson
{
    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return $"Name: {this.Name}, Age: {this.Age}";
        }
    }
}
