namespace Problem1GroupPermutations
{
    using System;
    using System.Linq;
    using System.Text;

    public class GroupPermutations
    {
        static int[] charsCount;
        static int count;
        static StringBuilder result = new StringBuilder();

        public static void Main()
        {
            string input = Console.ReadLine();
            charsCount = new int[26];
            foreach (var ch in input)
            {
                charsCount[ch - 'A']++;
            }

            char[] permute = input.ToCharArray().Distinct().ToArray();
            count = permute.Length;

            Permutate(permute, 0);
            Console.WriteLine(result.ToString().Trim());
        }

        private static void Permutate(char[] chars, int index)
        {
            if (index == count)
            {
                for (int i = 0; i < count; i++)
                {
                    int charCount = charsCount[chars[i] - 'A'];
                    for (int j = 0; j < charCount; j++)
                    {
                        result.Append(chars[i]);
                    }
                }

                result.AppendLine();
                return;
            }

            for (int i = index; i < chars.Length; i++)
            {
                Swap(ref chars[i], ref chars[index]);
                Permutate(chars, index + 1);
                Swap(ref chars[index], ref chars[i]);
            }
        }

        static void Swap(ref char first, ref char second)
        {
            if (first == second)
            {
                return;
            }

            char old = first;
            first = second;
            second = old;
        }
    }
}