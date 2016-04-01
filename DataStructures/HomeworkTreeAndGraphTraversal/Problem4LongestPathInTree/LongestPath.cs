namespace Problem4LongestPathInTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LongestPath
    {
        private static long maxSum = 0;

        public static void Main()
        {
            int nodesCount = int.Parse(Console.ReadLine());
            int edgesCount = int.Parse(Console.ReadLine());

            var tree = new Dictionary<int, Node>();
            for (int i = 0; i < edgesCount; i++)
            {
                int[] pair = Console.ReadLine().Split().Select(int.Parse).ToArray();
                if (!tree.ContainsKey(pair[0]))
                {
                    tree.Add(pair[0], new Node(pair[0]));
                }

                if (!tree.ContainsKey(pair[1]))
                {
                    tree.Add(pair[1], new Node(pair[1]));
                }

                tree[pair[0]].Children.Add(tree[pair[1]]);
                tree[pair[1]].Parent = tree[pair[0]];
            }
            
            var rootNode = tree.Where(n => n.Value.Parent == null).Select(n => n.Value).FirstOrDefault();
            var leaves = tree.Where(n => n.Value.Children.Count == 0).Select(n => n.Value);
            var pathsToRoot = new List<List<int>>();

            foreach (var leaf in leaves)
            {
                var currentPath = new List<int>();
                var currentNode = leaf;
                while (currentNode != rootNode)
                {
                    currentPath.Add(currentNode.Value);
                    currentNode = currentNode.Parent;
                }

                pathsToRoot.Add(currentPath);
            }

            int maxPathSum = int.MinValue;
            for (int i = 0; i < pathsToRoot.Count; i++)
            {
                for (int j = 0; j < pathsToRoot.Count; j++)
                {
                    if (i != j && pathsToRoot[i].Intersect(pathsToRoot[j]).Count() == 0)
                    {
                        int currentSum = pathsToRoot[i].Sum() + pathsToRoot[j].Sum() + rootNode.Value;

                        if (currentSum > maxPathSum)
                        {
                            maxPathSum = currentSum;
                        }
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine(maxPathSum);
        }
    }
}
