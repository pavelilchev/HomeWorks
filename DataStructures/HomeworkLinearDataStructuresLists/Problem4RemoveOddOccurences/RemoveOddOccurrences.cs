namespace Problem4RemoveOddOccurences
{
    using System;
    using System.Linq;

    public static class RemoveOddOccurrences
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                return;
            }

            var numbers = input.Split().Select(int.Parse).ToList();
            for (int i = 0; i < numbers.Count; i++)
            {
                int currentNum = numbers[i];
                int occurrenceCount = numbers.Count(t => t == currentNum);

                if (occurrenceCount % 2 != 0)
                {
                    numbers.RemoveAll(n => n == currentNum);
                    i--;
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
