namespace Problem4ShortestPathsBetweenAllPairsOfNodes
{
    using System;
    using System.Linq;

    public class FloydWarshall
    {
        public static void Main()
        {
            int vertexCount = Console.ReadLine().Split().Skip(1).Select(int.Parse).First();
            int edgesCount = Console.ReadLine().Split().Skip(1).Select(int.Parse).First();

            var graph = new double[vertexCount, vertexCount];
            for (int i = 0; i < edgesCount; i++)
            {
                var edgesArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int from = edgesArgs[0];
                int to = edgesArgs[1];
                int weight = edgesArgs[2];

                graph[from, to] = weight;
                graph[to, from] = weight;
            }

            var dist = graph.Clone() as double[,];
            for (int i = 0; i < vertexCount; i++)
            {
                for (int j = 0; j < vertexCount; j++)
                {
                    if (i != j && dist[i, j] == 0)
                    {
                        dist[i, j] = double.PositiveInfinity;
                    }
                }
            }
            
            for (int k = 0; k < vertexCount; k++)
            {
                for (int i = 0; i < vertexCount; i++)
                {
                    for (int j = 0; j < vertexCount; j++)
                    {
                        if (dist[i, k] + dist[k, j] < dist[i, j])
                        {
                            dist[i, j] = dist[i, k] + dist[k, j];
                        }
                    }
                }
            }

            Console.WriteLine("Shortest paths matrix:");
            for (int i = 0; i < vertexCount; i++)
            {
                Console.Write("{0, -3}", i);
            }

            Console.WriteLine();
            Console.WriteLine(new string('-', vertexCount * 3));
            for (int i = 0; i < vertexCount; i++)
            {
                for (int j = 0; j < vertexCount; j++)
                {
                    Console.Write("{0, -3}", dist[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
