namespace Problem2RoundDance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RoundDance
    {
        private static int maxLength = 0;

        public static void Main()
        {
            int numberOfEdges = int.Parse(Console.ReadLine());
            int startNood = int.Parse(Console.ReadLine());

            var structure = new Dictionary<int, Node>();

            for (int i = 0; i < numberOfEdges; i++)
            {
                int[] friendships = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (!structure.ContainsKey(friendships[0]))
                {
                    structure.Add(friendships[0], new Node(friendships[0]));
                }

                if (!structure.ContainsKey(friendships[1]))
                {
                    structure.Add(friendships[1], new Node(friendships[1]));
                }

                structure[friendships[0]].Neighbors.Add(structure[friendships[1]]);
                structure[friendships[1]].Neighbors.Add(structure[friendships[0]]);
            }

            //foreach (var node in structure.Values)
            //{
            //    Console.WriteLine("Value: {0}, Neighbords {1}", node.Value, string.Join(",", node.Neighbors));
            //}

            var stack = new Stack<Node>();
            var visited = new HashSet<int>();
            var node = structure[startNood];
            stack.Push(node);
            FindLongesRoundDance(node, visited, 0);

            Console.WriteLine(maxLength);
        }

        static void FindLongesRoundDance(Node node, HashSet<int> visited, int currentLength)
        {
            if (!visited.Contains(node.Value))
            {
                visited.Add(node.Value);

                currentLength++;
                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                }

                foreach (var childNode in node.Neighbors)
                {
                    FindLongesRoundDance(childNode, visited, currentLength);
                }

                currentLength = 1;
            }
        }
    }
}
