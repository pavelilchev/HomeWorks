namespace Problem5CombinationsWithoutRepetition
{
    using System;

    public class CombinationsWithoutRepetition
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            var vector = new int[k];
            GenCombinations(vector, 0, 1, n);
        }

        private static void GenCombinations(int[] vector, int index, int start, int count)
        {
            if (index == vector.Length)
            {
                Console.WriteLine("({0})", string.Join(" ", vector));
            }
            else
            {
                for (int i = start; i <= count; i++)
                {
                    vector[index] = i;
                    GenCombinations(vector,index+1,i+1,count);
                }
            }
        }
    }
}
