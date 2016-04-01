namespace Problem1FindTheRoot
{
    using System;
    using System.Linq;

    public class FindTheRoot
    {
        public static void Main()
        {
            int numberOfNodes = int.Parse(Console.ReadLine());
            int numbersOfEdges = int.Parse(Console.ReadLine());
            var structure = new Node[numberOfNodes];
            for (int i = 0; i < numberOfNodes; i++)
            {
                structure[i] = new Node(i);
            }

            for (int i = 0; i < numbersOfEdges; i++)
            {
                int[] parentChild = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int parent = parentChild[0];
                int child = parentChild[1];

                structure[parent].Children.Add(structure[child]);
                structure[child].Parents.Add(structure[parent]);
            }

            //foreach (var node in structure)
            //{
            //    Console.WriteLine("Node: {2} - Parents: {0}, Children: {1}", string.Join(", ", node.Parents), string.Join(", ", node.Children), node.Value);
            //}

            int rootCount = 0;
            Node rootNode = null;

            foreach (var node in structure)
            {
                if (node.Parents.Count == 0)
                {
                    rootCount++;
                    rootNode = node;
                }
            }

            if (rootCount == 0)
            {
                Console.WriteLine("No root!");
            }
            else if (rootCount == 1)
            {
                Console.WriteLine(rootNode.Value);
            }
            else
            {
                Console.WriteLine("Multiple root nodes!");
            }
        }
    }
}
