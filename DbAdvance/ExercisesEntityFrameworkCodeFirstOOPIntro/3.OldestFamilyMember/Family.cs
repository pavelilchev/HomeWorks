namespace _3.OldestFamilyMember
{
    using System.Collections.Generic;
    using System.Linq;

    public class Family
    {
        public Family()
        {
            this.Persons = new List<Person>();
        }

        public ICollection<Person> Persons { get; set; }

        public void AddMember(Person member)
        {
            this.Persons.Add(member);
        }

        public Person GetOldestMember()
        {
            return this.Persons.OrderByDescending(p => p.Age).FirstOrDefault();
        }
    }
}
