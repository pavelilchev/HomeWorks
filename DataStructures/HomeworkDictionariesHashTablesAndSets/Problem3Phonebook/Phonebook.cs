namespace Problem3Phonebook
{
    using System.Collections.Generic;

    public class Phonebook
    {
        private readonly IDictionary<string, string> entries;

        public Phonebook()
        {
            this.entries = new Dictionary<string, string>();
        }

        public void AddNumber(string name, string number)
        {
            if (!this.entries.ContainsKey(name))
            {
                this.entries.Add(name, number);
            }
            else
            {
                this.entries[name] = number;
            }
        }

        public string Search(string name)
        {
            string output;
            if (!this.entries.ContainsKey(name))
            {
                output = $"Contact {name} does not exist.";
            }
            else
            {
                output = $"{name} -> {this.entries[name]}";
            }

            return output;
        }
    }
}
