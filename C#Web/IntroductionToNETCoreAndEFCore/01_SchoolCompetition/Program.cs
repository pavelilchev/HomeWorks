namespace _01_SchoolCompetition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var categories = new Dictionary<string, SortedSet<string>>();
            var result = new Dictionary<string, int>();
            while(true)
            {
                var line = Console.ReadLine();
                if(line == "END")
                {
                    break;
                }

                var parts = line.Split();
                var name = parts[0];
                var category = parts[1];
                var points = int.Parse(parts[2]);

                if (!categories.ContainsKey(name))
                {
                    categories.Add(name, new SortedSet<string>());
                }

                if (!result.ContainsKey(name))
                {
                    result.Add(name, 0);
                }

                categories[name].Add(category);
                result[name] += points;
            }

            var orderedResult = result
                .OrderByDescending(r => r.Value)
                .ThenBy(r => r.Key);

            foreach (var c in orderedResult)
            {
                var currentCategories = string.Join(", ", categories[c.Key]);
                Console.WriteLine($"{c.Key}: {c.Value}[{currentCategories}]");
            }
        }
    }
}
