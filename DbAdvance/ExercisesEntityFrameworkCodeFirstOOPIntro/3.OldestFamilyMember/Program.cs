namespace _3.OldestFamilyMember
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int count = int.Parse(Console.ReadLine());
            var family = new Family();

            for (int i = 0; i < count; i++)
            {
                var pi = Console.ReadLine().Split();
                family.AddMember(new Person(pi[0], int.Parse(pi[1])));
            }

            Console.WriteLine(family.GetOldestMember());
        }
    }
}
