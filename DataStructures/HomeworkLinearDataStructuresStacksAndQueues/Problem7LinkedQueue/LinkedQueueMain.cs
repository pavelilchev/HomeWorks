namespace Problem7LinkedQueue
{
    using System;

    public static class LinkedQueueMain
    {
        public static void Main()
        {
            var queue = new LinkedQueue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

            var arr = queue.ToArray();

            Console.WriteLine(string.Join(", ", arr));

            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }
        }
    }
}
