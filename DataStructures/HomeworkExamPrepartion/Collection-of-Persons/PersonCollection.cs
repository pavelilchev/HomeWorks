namespace CollectionOfPersons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class PersonCollection : IPersonCollection
    {
        private readonly Dictionary<string, Person> personsByEmail;
        private readonly Dictionary<string, SortedSet<Person>> personsByDomain;
        private readonly Dictionary<Tuple<string, string>, SortedSet<Person>> personsByNameAndTown;
        private readonly OrderedDictionary<int, SortedSet<Person>> personsByAge;
        private readonly Dictionary<string, OrderedDictionary<int, SortedSet<Person>>> personsByTownAndAge;

        public PersonCollection()
        {
            this.personsByEmail = new Dictionary<string, Person>();
            this.personsByDomain = new Dictionary<string, SortedSet<Person>>();
            this.personsByNameAndTown = new Dictionary<Tuple<string, string>, SortedSet<Person>>();
            this.personsByAge = new OrderedDictionary<int, SortedSet<Person>>();
            this.personsByTownAndAge = new Dictionary<string, OrderedDictionary<int, SortedSet<Person>>>();
        }

        public bool AddPerson(string email, string name, int age, string town)
        {
            if (this.personsByEmail.ContainsKey(email))
            {
                return false;
            }

            var person = new Person(email, name, age, town);
            this.personsByEmail.Add(email, person);
            string domain = email.Split('@')[1];
            if (!this.personsByDomain.ContainsKey(domain))
            {
                this.personsByDomain.Add(domain, new SortedSet<Person>());
            }
            this.personsByDomain[domain].Add(person);
            var tuple = new Tuple<string, string>(name, town);
            if (!this.personsByNameAndTown.ContainsKey(tuple))
            {
                this.personsByNameAndTown.Add(tuple, new SortedSet<Person>());
            }
            this.personsByNameAndTown[tuple].Add(person);
            this.personsByAge.AppendValueToKey(age, person);

            // Add by {age + town}
            this.personsByTownAndAge.EnsureKeyExists(town);
            this.personsByTownAndAge[town].AppendValueToKey(age, person);
            return true;
        }

        public int Count => this.personsByEmail.Count;

        public Person FindPerson(string email)
        {
            Person person;
            this.personsByEmail.TryGetValue(email, out person);

            return person;
        }

        public bool DeletePerson(string email)
        {
            Person person;
            if (!this.personsByEmail.TryGetValue(email, out person))
            {
                return false;
            }

            this.personsByEmail.Remove(email);
            string domain = person.Email.Split('@')[1];
            this.personsByDomain[domain].Remove(person);
            var tuple = new Tuple<string, string>(person.Name, person.Town);
            this.personsByNameAndTown[tuple].Remove(person);
            this.personsByAge[person.Age].Remove(person);
            this.personsByTownAndAge[person.Town][person.Age].Remove(person);

            return true;
        }

        public IEnumerable<Person> FindPersons(string emailDomain)
        {
            if (!this.personsByDomain.ContainsKey(emailDomain))
            {
                yield break;
            }

            var people = this.personsByDomain[emailDomain];
            foreach (var person in people)
            {
                yield return person;
            }
        }

        public IEnumerable<Person> FindPersons(string name, string town)
        {
            var tuple = new Tuple<string, string>(name, town);
            if (!this.personsByNameAndTown.ContainsKey(tuple))
            {
                yield break;
            }

           var people = this.personsByNameAndTown[tuple];

            foreach (var person in people)
            {
                yield return person;
            }
        }

        public IEnumerable<Person> FindPersons(int startAge, int endAge)
        {
            var range = this.personsByAge.Range(startAge, true, endAge, true);

            foreach (var personsByAge in range)
            {
                foreach (var person in personsByAge.Value)
                {
                    yield return person;
                }
            }
        }

        public IEnumerable<Person> FindPersons(
            int startAge, int endAge, string town)
        {
            if (!this.personsByTownAndAge.ContainsKey(town))
            {
                yield break;
            }

            var personsInRange = this.personsByTownAndAge[town]
              .Range(startAge, true, endAge, true);

            foreach (var personsByAge in personsInRange)
            {
                foreach (var person in personsByAge.Value)
                {
                    yield return person;
                }
            }
        }
    }
}
