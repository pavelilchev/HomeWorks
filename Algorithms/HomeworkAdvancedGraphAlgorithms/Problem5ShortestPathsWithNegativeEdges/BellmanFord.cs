namespace Problem5ShortestPathsWithNegativeEdges
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BellmanFord
    {
        static List<int> negativeCycle = new List<int>(); 

        public static void Main()
        {
            int nodesCount = Console.ReadLine().Split().Skip(1).Select(int.Parse).First();
            int[] startEnd = Console.ReadLine().Split(new []{' ', '-'}, StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(int.Parse).ToArray();
            int edgesCount = Console.ReadLine().Split().Skip(1).Select(int.Parse).First();

            var graph = new List<Edge>();
            for (int i = 0; i < edgesCount; i++)
            {
                var edgeArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var edge = new Edge(edgeArgs[0], edgeArgs[1], edgeArgs[2]);
                graph.Add(edge);
            }

            var distance = new double[nodesCount];
            var predecessor = new int[nodesCount];
            for (int i = 0; i < nodesCount; i++)
            {
                distance[i] = double.PositiveInfinity;
                predecessor[i] = -1;
            }

            int source = startEnd[0];
            int destination = startEnd[1];
            distance[source] = 0;

            for (int i = 0; i < nodesCount - 1; i++)
            {
                foreach (var edge in graph)
                {
                    if (edge.Weight + distance[edge.From] < distance[edge.To])
                    {
                        distance[edge.To] = edge.Weight + distance[edge.From];
                        predecessor[edge.To] = edge.From;
                    }
                }
            }

            foreach (var edge in graph)
            {
                if (edge.Weight + distance[edge.From] < distance[edge.To])
                {
                    PrintNegativeCycle(edge.From, edge, graph);
                    return;
                }
            }

            var path = new Stack<int>();
            Console.WriteLine("Distance [{0} -> {1}]: {2}",source, destination, distance[destination]);
           
            while (predecessor[destination] != -1)
            {
                path.Push(destination);
                destination = predecessor[destination];
            }

            path.Push(destination);
            Console.WriteLine(string.Join(" -> ", path));
        }

        private static void PrintNegativeCycle(int from, Edge edge, List<Edge> graph)
        {
            if (from == edge.To)
            {
                negativeCycle.Add(edge.To);
                Console.WriteLine(string.Join(" -> ", negativeCycle));
                return;
            }

            foreach (var e in graph)
            {
                if (e.From == edge.To)
                {
                    negativeCycle.Add(e.From);
                    PrintNegativeCycle(from, e, graph);
                    negativeCycle.RemoveAt(negativeCycle.Count - 1);
                }
            }
        }

        private class Edge
        {
            public Edge(int from, int to, int weight)
            {
                this.From = from;
                this.To = to;
                this.Weight = weight;
            }

            public int From { get; private set; }

            public int To { get; private set; }

            public int Weight { get; private set; }
        }
    }
}
