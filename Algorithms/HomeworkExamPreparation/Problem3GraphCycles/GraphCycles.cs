namespace Problem3GraphCycles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GraphCycles
    {
        public static void Main()
        {
            int nodesCount = int.Parse(Console.ReadLine());
            var graph = new SortedSet<int>[nodesCount];
            for (int i = 0; i < nodesCount; i++)
            {
                var node = Console.ReadLine().Split(new[] {' ', '-', '>'}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                graph[node[0]] = new SortedSet<int>();
                for (int j = 1; j < node.Length; j++)
                {
                    graph[node[0]].Add(node[j]);
                }
            }

            bool haveCycle = false;
            for (int i = 0; i < nodesCount; i++)
            {
                foreach (int child1 in graph[i])
                {
                    if (child1 > i)
                    {
                        foreach (int child2 in graph[child1])
                        {
                            if (child2 > i && child2!= child1)
                            {
                                if (graph[child2].Contains(i))
                                {
                                    Console.WriteLine($"{{{i} -> {child1} -> {child2}}}");
                                    haveCycle = true;
                                }
                            }
                        }
                    }
                }
            }

            if (!haveCycle)
            {
                Console.WriteLine("No cycles found");
            }
        }
    }
}
