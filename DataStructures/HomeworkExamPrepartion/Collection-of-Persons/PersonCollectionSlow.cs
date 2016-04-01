namespace CollectionOfPersons
{
    using System.Collections.Generic;
    using System.Linq;

    public class PersonCollectionSlow : IPersonCollection
    {
        private readonly List<Person> persons;

        public PersonCollectionSlow()
        {
            this.persons = new List<Person>();
        } 

        public bool AddPerson(string email, string name, int age, string town)
        {
            var person = new Person(email, name, age, town);
            if (this.persons.Any(p=>p.Email == email))
            {
                return false;
            }

            this.persons.Add(person);
            return true;
        }

        public int Count => this.persons.Count;
  
        public Person FindPerson(string email)
        {
            var person = this.persons.FirstOrDefault(p => p.Email == email);
            return person;
        }

        public bool DeletePerson(string email)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.persons[i].Email == email)
                {
                    this.persons.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        public IEnumerable<Person> FindPersons(string emailDomain)
        {
            var personsByDomain = this.persons.Where(p => p.Email.EndsWith('@' + emailDomain)).OrderBy(p=>p);

            return personsByDomain;
        }

        public IEnumerable<Person> FindPersons(string name, string town)
        {
            var personsByTownAndName = this.persons.Where(p => p.Name == name && p.Town == town).OrderBy(p => p);

            return personsByTownAndName;
        }

        public IEnumerable<Person> FindPersons(int startAge, int endAge)
        {
            var personsByAge = this.persons.Where(p => p.Age >= startAge && p.Age <= endAge).OrderBy(p => p.Age).ThenBy(p=>p.Email);

            return personsByAge;
        }

        public IEnumerable<Person> FindPersons(
            int startAge, int endAge, string town)
        {
            var personsByAgeAndTown = this.persons.Where(p => p.Town == town && p.Age >= startAge && p.Age <= endAge).OrderBy(p => p.Age).ThenBy(p => p.Email);

            return personsByAgeAndTown;
        }
    }
}
