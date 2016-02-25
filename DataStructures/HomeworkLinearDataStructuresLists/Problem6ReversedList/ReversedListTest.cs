namespace ReversedList
{
    using System;

    public static class ReversedListTest
    {
        public static void Main()
        {
            var reversedList = new ReversedList<int>();

            reversedList.Add(1);
            reversedList.Add(2);
            reversedList.Add(3);
            reversedList.Add(4);

            foreach (int element in reversedList)
            {
                Console.WriteLine(element);
            }

            reversedList[0] = 5;

            Console.WriteLine(string.Join(", ", reversedList));
            Console.WriteLine(reversedList[0]);
            Console.WriteLine(reversedList[3]);

            reversedList.Remove(0);
            Console.WriteLine(string.Join(", ", reversedList));

            Console.WriteLine("Count: " + reversedList.Count);
            Console.WriteLine("Capacity: " + reversedList.Capacity);
        }
    }
}
