namespace Problem5LinkedStack
{
    using System;

    public static class LinkedStackMain
    {
        public static void Main()
        {
            var stack = new LinkedStack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }

            stack.Push(-1);
            stack.Push(-2);
            stack.Push(-3);

            var arr = stack.ToArray();

            Console.WriteLine(string.Join(", ", arr));
        }
    }
}
