namespace Problem1PlayWithTrees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class PlayWithTrees
    {
        private static Dictionary<int, Tree<int>> nodeByValue = new Dictionary<int, Tree<int>>();
        private static Stack<Tree<int>> longestPath = new Stack<Tree<int>>();
        private static List<string> pathsWhitGivenSum = new List<string>();
        private static List<string> subtreeWhitGivenSum = new List<string>();

        public static void Main()
        {
            int nodesCount = int.Parse(Console.ReadLine());

            for (int i = 1; i < nodesCount; i++)
            {
                string[] edge = Console.ReadLine().Split();
                int parentValue = int.Parse(edge[0]);
                Tree<int> parentNode = GetTreeNodeByValue(parentValue);
                int childValue = int.Parse(edge[1]);
                Tree<int> childNode = GetTreeNodeByValue(childValue);
                parentNode.Children.Add(childNode);
                childNode.Parent = parentNode;
            }

            int pathSum = int.Parse(Console.ReadLine());
            int subtreeSum = int.Parse(Console.ReadLine());

            var root = FindRootNode();
            Console.WriteLine("Root node: " + root.Value);
            Console.WriteLine();

            var leafNodes = FindLeafNodes();
            Console.WriteLine("Leaf nodes: " + string.Join(", ", leafNodes));
            Console.WriteLine();

            var middleNodes = FindMiddleNodes();
            Console.WriteLine("Middle nodes: " + string.Join(", ", middleNodes));
            Console.WriteLine();


            var path = new Stack<Tree<int>>();
            path.Push(root);
            FindLongestPath(root, path);
            Console.WriteLine("Longest path:");
            Console.WriteLine(string.Join(" -> ", longestPath));
            Console.WriteLine("(length = {0})", longestPath.Count);
            Console.WriteLine();

            var pathForSum = new Stack<Tree<int>>();
            pathForSum.Push(root);
            FindPathWhitSum(root, pathForSum, pathSum);
            Console.WriteLine("Paths of sum {0}:", pathSum);
            Console.WriteLine(string.Join(Environment.NewLine, pathsWhitGivenSum));
            Console.WriteLine();

            FindSubtreeByGivenSum(subtreeSum);
            Console.WriteLine("Subtrees of sum {0}:", subtreeSum);
            Console.WriteLine(string.Join(Environment.NewLine, subtreeWhitGivenSum));
        }

        private static void FindSubtreeByGivenSum(int neededSum)
        {
            foreach (var node in nodeByValue.Values)
            {
                var queue = new Queue<int>();
                InOrderTraverse(node, queue);

                if (queue.Sum() == neededSum)
                {
                    subtreeWhitGivenSum.Add(string.Join(" + ", queue));
                }
            }
        }

        private static void InOrderTraverse(Tree<int> node, Queue<int> queue)
        {
            queue.Enqueue(node.Value);

            foreach (var child in node.Children)
            {
                InOrderTraverse(child, queue);
            }
        }

        private static void FindPathWhitSum(Tree<int> root, Stack<Tree<int>> path, int sum)
        {
            foreach (var child in root.Children)
            {
                path.Push(child);
                FindPathWhitSum(child, path, sum);

                if (path.Sum(n => n.Value) == sum)
                {
                    var result = path.ToArray().Reverse();
                    pathsWhitGivenSum.Add(string.Join(" -> ", result));
                }

                path.Pop();
            }
        }

        private static void FindLongestPath(Tree<int> root, Stack<Tree<int>> path)
        {
            foreach (var child in root.Children)
            {
                path.Push(child);
                FindLongestPath(child, path);

                if (path.Count > longestPath.Count)
                {
                    longestPath.Clear();
                    foreach (var tree in path)
                    {
                        longestPath.Push(tree);
                    }
                }

                path.Pop();
            }
        }

        private static IEnumerable<Tree<int>> FindLeafNodes()
        {
            var liefNodes = nodeByValue
                .Values
                .Where(n => n.Children.Count == 0)
                .OrderBy(n => n.Value)
                .ToList();

            return liefNodes;
        }

        private static void PrintTree(Tree<int> root, int indent = 0)
        {
            Console.Write(new string(' ', 2 * indent));
            Console.WriteLine(root.Value);

            foreach (var child in root.Children)
            {
                PrintTree(child, indent + 1);
            }
        }

        private static IEnumerable<Tree<int>> FindMiddleNodes()
        {
            var middleNodes = nodeByValue
                .Values
                .Where(n => n.Children.Count > 0 && n.Parent != null)
                .OrderBy(n => n.Value)
                .ToList();

            return middleNodes;
        }

        private static Tree<int> FindRootNode()
        {
            var rootNode = nodeByValue.Values.FirstOrDefault(node => node.Parent == null);

            return rootNode;
        }

        private static Tree<int> GetTreeNodeByValue(int value)
        {
            if (!nodeByValue.ContainsKey(value))
            {
                nodeByValue[value] = new Tree<int>(value);
            }

            return nodeByValue[value];
        }
    }
}
