namespace Problem1DistanceBetweenVertices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DistanceBetweenVertices
    {
        private static Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        private static HashSet<int> visited;
        public static void Main()
        {
            Console.ReadLine();
            string line = Console.ReadLine();
            while (line != "Distances to find:")
            {
                int[] vertex =
                    line.Split(new char[] {' ', '-', '>', ','}, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                if (!graph.ContainsKey(vertex[0]))
                {
                    graph.Add(vertex[0], new List<int>());
                }

                for (int i = 1; i < vertex.Length; i++)
                {
                    graph[vertex[0]].Add(vertex[i]);
                }

                line = Console.ReadLine();
            }

            line = Console.ReadLine();
            while (line != "end")
            {
                int[] verticesPair = line.Split('-').Select(int.Parse).ToArray();

                int distance = FindDistance(verticesPair[0], verticesPair[1]);
                Console.WriteLine(distance);

                line = Console.ReadLine();
            }
        }

        private static int FindDistance(int from, int to)
        {
            visited = new HashSet<int> {from};
            var queue = new Queue<Tuple<int,int>>();
            queue.Enqueue(new Tuple<int, int>(from, 0));
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (current.Item1 == to)
                {
                    return current.Item2;
                }

                foreach (int child in graph[current.Item1])
                {
                    if (visited.Contains(child))
                    {
                        continue;
                    }

                    visited.Add(child);
                    queue.Enqueue(new Tuple<int, int>(child, current.Item2 + 1));
                }
            }

            return -1;
        }
    }
}
