namespace Problem1StudentsAndCourses
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class StudentsCoursesMain
    {
        public static void Main()
        {
            var personsByCourse = new SortedDictionary<string, SortedSet<Person>>();
            using (StreamReader sr = File.OpenText(@"..\..\students.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var lineTokens = line.Split('|');
                    string firstName = lineTokens[0].Trim();
                    string lastName = lineTokens[1].Trim();
                    string courseName = lineTokens[2].Trim();
                    var person = new Person(firstName, lastName);

                    if (!personsByCourse.ContainsKey(courseName))
                    {
                        personsByCourse.Add(courseName, new SortedSet<Person>());
                    }

                    personsByCourse[courseName].Add(person);
                }
            }

            foreach (var pair in personsByCourse)
            {
                Console.WriteLine("{0}: {1}", pair.Key, string.Join(", ", pair.Value));
            }
        }
    }
}
