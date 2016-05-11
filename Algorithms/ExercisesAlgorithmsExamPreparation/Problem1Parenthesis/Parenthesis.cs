namespace Problem1Parenthesis
{
    using System;
    using System.Text;

    public class Parenthesis
    {
        private static int open = 0;
        private static int closed = 0;
        private static int n;
        static StringBuilder output = new StringBuilder();

        public static void Main()
        {
            n = int.Parse(Console.ReadLine());
            var vector = new char[n * 2];
            GenParenthesisCombination(0, vector);
            Console.Write(output);
        }

        private static void GenParenthesisCombination(int index, char[] vector)
        {
            if (index == vector.Length)
            {
               output.AppendLine(new string(vector));
                return;
            }

            if (open < n)
            {
                vector[index] = '(';
                open++;
                GenParenthesisCombination(index + 1, vector);
                open--;
            }

            if (closed < open)
            {
                vector[index] = ')';
                closed++;
                GenParenthesisCombination(index + 1, vector);
                closed--;
            }
        }
    }
}
