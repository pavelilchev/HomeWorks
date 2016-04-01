namespace Problem3MassEffectGalaxyMap
{
    using System;
    using System.Collections.Generic;

    public class MassEffectMain
    {
        public static void Main()
        {
            int starClustersCount = int.Parse(Console.ReadLine());
            var sortedClusters = new SortedSet<Cluster>();
            for (int i = 0; i < starClustersCount; i++)
            {
                var starClustersArgs = Console.ReadLine().Split();
                string name = starClustersArgs[0];
                double x = double.Parse(starClustersArgs[1]);
                double y = double.Parse(starClustersArgs[2]);
                sortedClusters.Add(new Cluster(name, x, y));
            }

            var tree = new KdTree();
            foreach (var cluster in sortedClusters)
            {
                tree.Add(cluster);
            }

            var report = Console.ReadLine().Split();
            double cursorX = double.Parse(report[1]);
            double cursorY = double.Parse(report[2]);
            double radius = double.Parse(report[3]);
        }
    }
}
