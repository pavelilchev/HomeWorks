namespace Problem7LinkedList
{
    using System;

    public static class LinkedListTest
    {
        public static void Main()
        {
            var linkedList = new LinkedList<int>();
            Console.WriteLine(linkedList.FirstIndexOf(3));
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);
            linkedList.Add(4);
            linkedList.Add(1);

            Console.WriteLine(string.Join(", ", linkedList));
            Console.WriteLine(linkedList.Count);

            linkedList.Remove(1);
            Console.WriteLine(string.Join(", ", linkedList));
            Console.WriteLine(linkedList.FirstIndexOf(3));
            Console.WriteLine(linkedList.LastIndexOf(1));
        }
    }
}
