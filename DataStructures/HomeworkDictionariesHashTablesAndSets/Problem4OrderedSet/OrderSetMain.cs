namespace Problem4OrderedSet
{
    using System;

    public static class OrderSetMain
    {
        public static void Main()
        {
            var set = new OrderedSet<string>();
            set.Add("abc");
            set.Add("dfe");
            set.Add("dfw");
            set.Add("dfw");
            set.Add("abd");
            set.Add("adr");

            foreach (var i in set)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine(set.Contains("dfe"));
            Console.WriteLine(set.Contains("dfde"));

            set.Remove("abd");
            foreach (var i in set)
            {
                Console.WriteLine(i);
            }
        }
    }
}
