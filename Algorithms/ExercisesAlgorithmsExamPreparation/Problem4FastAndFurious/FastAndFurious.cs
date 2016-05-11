namespace Problem4FastAndFurious
{
    using System;
    using System.Collections.Generic;

    public class FastAndFurious
    {
        private static Dictionary<string, Node> nodes;
        private static double[,] graph;

        public static void Main()
        {
            Console.ReadLine();
            string line = Console.ReadLine();
            nodes = new Dictionary<string, Node>();
            while (line != "Records:")
            {
                var cameranameDistanceSpeed = line.Split();
                string from = cameranameDistanceSpeed[0];
                string to = cameranameDistanceSpeed[1];
                double distance = double.Parse(cameranameDistanceSpeed[2]);
                double speedLimit = double.Parse(cameranameDistanceSpeed[3]);
                if (!nodes.ContainsKey(from))
                {
                    nodes.Add(from, new Node(from));
                }

                if (!nodes.ContainsKey(to))
                {
                    nodes.Add(to, new Node(to));
                }

                var fromNode = nodes[from];
                var toNode = nodes[to];
                fromNode.Edges.Add(new Edge(toNode, distance, speedLimit));
                toNode.Edges.Add(new Edge(fromNode, distance, speedLimit));

                line = Console.ReadLine();
            }

            graph = new double[nodes.Count, nodes.Count];

            foreach (var node in nodes.Values)
            {
                int fromId = node.Id;
                foreach (var edge in node.Edges)
                {
                    int toId = edge.ToNode.Id;
                    double time = edge.Time;
                    graph[fromId, toId] = time;
                    graph[toId, fromId] = time;
                }
            }

            var bestTimes = graph.Clone() as double[,];
            int vertexCount = nodes.Count;
            for (int i = 0; i < vertexCount; i++)
            {
                for (int j = 0; j < vertexCount; j++)
                {
                    if (i != j && bestTimes[i, j] == 0)
                    {
                        bestTimes[i, j] = double.PositiveInfinity;
                    }
                }
            }

            for (int k = 0; k < vertexCount; k++)
            {
                for (int i = 0; i < vertexCount; i++)
                {
                    for (int j = 0; j < vertexCount; j++)
                    {
                        if (bestTimes[i, k] + bestTimes[k, j] < bestTimes[i, j])
                        {
                            bestTimes[i, j] = bestTimes[i, k] + bestTimes[k, j];
                        }
                    }
                }
            }
            

            line = Console.ReadLine();
            var records = new Dictionary<string, List<Record>>();
            var result = new SortedSet<string>();
            while (line != "End")
            {
                var cameraNameLicenseTime = line.Split();
                string name = cameraNameLicenseTime[0];
                string licensePlate = cameraNameLicenseTime[1];
                DateTime time = DateTime.Parse(cameraNameLicenseTime[2]);

                var record = new Record(name, licensePlate, time);
                if (records.ContainsKey(licensePlate))
                {
                    foreach (var oldRecord in records[licensePlate])
                    {
                        var from = nodes[oldRecord.Name];
                        var to = nodes[record.Name];

                        double fastTime = bestTimes[from.Id, to.Id];
                        if (fastTime != double.PositiveInfinity && fastTime > Math.Abs((record.Time - oldRecord.Time).TotalHours))
                        {
                            result.Add(licensePlate);
                        }
                    }
                }
                else
                {
                    records[licensePlate] = new List<Record>();
                }

                records[licensePlate].Add(record);
                line = Console.ReadLine();
            }

            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }

    public class Record
    {
        public Record(string name, string licensePlate, DateTime time)
        {
            this.Name = name;
            this.LicensePlate = licensePlate;
            this.Time = time;
        }

        public string Name { get; set; }

        public string LicensePlate { get; set; }

        public DateTime Time { get; set; }
    }

    public class Node : IComparable<Node>
    {
        private static int uniqueId = 0;

        public Node(string name)
        {
            this.Id = uniqueId++;
            this.Name = name;
            this.Edges = new List<Edge>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public double DijkstraTime { get; set; }

        public List<Edge> Edges { get; set; }

        public int CompareTo(Node other)
        {
            return this.DijkstraTime.CompareTo(other.DijkstraTime);
        }
    }

    public class Edge
    {
        public Edge(Node toNode, double distance, double speed)
        {
            this.ToNode = toNode;
            this.Distance = distance;
            this.Speed = speed;
            this.Time = distance/speed;
        }

        public Node ToNode { get; set; }

        public double Distance { get; set; }

        public double Speed { get; set; }

        public double Time { get; set; }
    }
}
