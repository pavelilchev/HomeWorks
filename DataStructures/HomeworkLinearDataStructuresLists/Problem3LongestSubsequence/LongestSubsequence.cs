namespace Problem3LongestSubsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class LongestSubsequence
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                return;
            }

            var numbers = input.Split().Select(int.Parse).ToList();

            var result = FindLongestSubsequence(numbers);

            Console.WriteLine(string.Join(" ", result));
        }

        private static List<int> FindLongestSubsequence(List<int> numbers)
        {
            if (numbers == null || numbers.Count == 0)
            {
                return new List<int>();
            }

            int firstIndex = 0;
            int count = 1;
            int maxIndex = 0;
            int maxCount = 0;

            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] == numbers[i - 1])
                {
                    count++;
                }
                else
                {
                    if (count > maxCount)
                    {
                        maxIndex = firstIndex;
                        maxCount = count;
                    }

                    firstIndex = i;
                    count = 1;
                }
            }

            if (count > maxCount)
            {
                maxIndex = firstIndex;
                maxCount = count;
            }

            List<int> result = new List<int>();
            for (int i = maxIndex; i < maxIndex + maxCount; i++)
            {
                result.Add(numbers[i]);
            }

            return result;
        }
    }
}
