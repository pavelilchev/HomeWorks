namespace Problem5Sorting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Sorting
    {
        public static void Main()
        {
            int numbersCount = int.Parse(Console.ReadLine());
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int consecutiveElementsCount = int.Parse(Console.ReadLine());

            int step = 1;
            var queue = new Queue<Sequence>();
            var reachedSequence = new HashSet<string>();
            queue.Enqueue(new Sequence(numbers, step));
            string hash = string.Join(",", numbers);
            reachedSequence.Add(hash);
            var sorted = new int[numbersCount];
            Array.Copy(numbers, sorted, numbersCount);
            Array.Sort(sorted);
            string sortedString = string.Join(",", sorted);
            if (sortedString == hash)
            {
                Console.WriteLine(0);
                return;
            }

            while (queue.Count > 0)
            {
                var element = queue.Dequeue();
                numbers = element.Numbers;

                for (int i = 0; i <= numbersCount - consecutiveElementsCount; i++)
                {
                    int[] subSequence = numbers.Skip(i).Take(consecutiveElementsCount).Reverse().ToArray();
                    var newArr = new int[numbersCount];
                    Array.Copy(numbers, newArr, numbersCount);

                    for (int j = 0; j < consecutiveElementsCount; j++)
                    {
                        newArr[i + j] = subSequence[j];
                    }

                    hash = string.Join(",", newArr);

                    if (sortedString == hash)
                    {
                        Console.WriteLine(element.Steps);
                        return;
                    }

                    if (!reachedSequence.Contains(hash))
                    {
                        reachedSequence.Add(hash);
                        queue.Enqueue(new Sequence(newArr, element.Steps + 1));
                    }
                }
            }

            Console.WriteLine(-1);
        }
    }
}
