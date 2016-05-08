namespace Problem1ExtendCableNetwork
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ExtendCableNetwork
    {
        public static void Main()
        {
            int budget = Console.ReadLine().Split().Skip(1).Select(int.Parse).First();
            int nodes = Console.ReadLine().Split().Skip(1).Select(int.Parse).First();
            int edges = Console.ReadLine().Split().Skip(1).Select(int.Parse).First();

            var usedVertex = new bool[nodes];
            var graph = new List<Edge>[nodes];
            for (int i = 0; i < nodes; i++)
            {
                graph[i] = new List<Edge>();
            }

            var priorityQueue = new PriorityQueue<Edge>();
            for (int i = 0; i < edges; i++)
            {
                string[] edgeAsString = Console.ReadLine().Split();
                int from = int.Parse(edgeAsString[0]);
                int to = int.Parse(edgeAsString[1]);
                int weight = int.Parse(edgeAsString[2]);
                var edge = new Edge(from, to, weight);
                graph[from].Add(edge);
                graph[to].Add(edge);

                if (edgeAsString.Length == 4)
                {
                    usedVertex[from] = true;
                    usedVertex[to] = true;
                }
            }
         
            for (int i = 0; i < nodes; i++)
            {
                if (usedVertex[i])
                {
                    foreach (var edge in graph[i])
                    {
                        priorityQueue.Enqueue(edge);
                    }
                }
            }

            var result = new List<Edge>();
            int budgetUsed = 0;

            while (priorityQueue.Count > 0)
            {
                var minEdge = priorityQueue.ExtractMin();
                int from = minEdge.From;
                int to = minEdge.To;
                int weight = minEdge.Weight;

                if ((usedVertex[from] && !usedVertex[to]) || 
                    (usedVertex[to] && !usedVertex[from]))
                {
                    budget -= weight;
                    if (budget < 0)
                    {
                        break;
                    }

                    if (!usedVertex[from])
                    {
                        foreach (var edge in graph[from])
                        {
                            priorityQueue.Enqueue(edge);
                        }
                    }
                    else
                    {
                        foreach (var edge in graph[to])
                        {
                            priorityQueue.Enqueue(edge);
                        }
                    }

                    budgetUsed += weight;
                    result.Add(minEdge);
                    usedVertex[from] = true;
                    usedVertex[to] = true;
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, result));
            Console.WriteLine("Budget used: " + budgetUsed);
        }
    }
}

