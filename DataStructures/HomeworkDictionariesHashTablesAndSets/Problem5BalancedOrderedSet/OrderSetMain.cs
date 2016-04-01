namespace Problem5BalancedOrderedSet
{
    using System;

    public static class OrderSetMain
    {
        public static void Main()
        {
            var set = new OrderedSet<int> {17, 9, 12, 19, 6, 25, 5, 13, 57, 1, -5, 45, 17, 0, -15};

            var root = set.Root;
           set.Print(0, root);

            Console.WriteLine(set.Contains(6));
            Console.WriteLine(set.Contains(18));

            set .Remove(6);
            root = set.Root;
            set.Print(0, root);
        }
    }
}
