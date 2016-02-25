namespace Problem2CalculateSequenceWithQueue
{
    using System;
    using System.Collections.Generic;

    public static class CalculateSequenceWithQueue
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            long currentElement;
            bool isNumber = long.TryParse(input, out currentElement);

            if (!isNumber)
            {
                throw new ArgumentException("Invalid number.");
            }

            var sequence = new Queue<long>();
            sequence.Enqueue(currentElement);
            int index = 0;

            while (true)
            {
                currentElement = sequence.Dequeue();
                Console.Write(currentElement);
                index++;
                if (index == 50)
                {
                    break;
                }

                Console.Write(", ");

                long addOne = currentElement + 1;
                sequence.Enqueue(addOne);
                long multipleTwo = 2*currentElement + 1;
                sequence.Enqueue(multipleTwo);
                long addTwo = currentElement + 2;
                sequence.Enqueue(addTwo);
            }

            Console.WriteLine();
        }
    }
}
