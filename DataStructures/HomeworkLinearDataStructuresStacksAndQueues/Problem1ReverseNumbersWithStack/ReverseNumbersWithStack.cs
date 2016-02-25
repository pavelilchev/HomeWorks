namespace Problem1ReverseNumbersWithStack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class ReverseNumbersWithStack
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                return;
            }

            var numbers = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse);

            var reversedNumbers = new Stack<int>(numbers);

            Console.WriteLine(string.Join(" ", reversedNumbers));
        }
    }
}
