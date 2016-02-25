namespace Problem3ImplementArrayBasedStack
{
    using System;

    public class ArrayStackMain
    {
        public static void Main()
        {
            var stack = new ArrayStack<int>();
            stack.Push(3);
            stack.Push(5);
            stack.Push(7);
            stack.Push(9);

            while (stack.Count > 0)
            {
                int currentNum = stack.Pop();
                Console.Write(currentNum + " ");
            }

            Console.WriteLine();

            stack.Push(-3);
            stack.Push(-5);
            stack.Push(-7);
            stack.Push(-9);

            var stackAsArray = stack.ToArray();
            Console.WriteLine(string.Join(", ", stackAsArray));
        }
    }
}
