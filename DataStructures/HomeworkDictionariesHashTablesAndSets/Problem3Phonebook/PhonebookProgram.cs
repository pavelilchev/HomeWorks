namespace Problem3Phonebook
{
    using System;

    public class PhonebookProgram
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            var phonebook = new Phonebook();

            while (input != "search" && input != null)
            {
                string[] param = input.Split('-');
                phonebook.AddNumber(param[0], param[1]);
                input = Console.ReadLine();
            }

            string name = Console.ReadLine();
            while (!string.IsNullOrEmpty(name))
            {
                var output = phonebook.Search(name);
                Console.WriteLine(output);
                name = Console.ReadLine();
            }
        }
    }
}
