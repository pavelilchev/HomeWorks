namespace Problem1AVLTree
{
    using System;
    using System.Linq;

    public class AvlTest
    {
        public static void Main()
        {
            var treeElements = Console.ReadLine().Split().Select(int.Parse);
            var tree = new AvlTree<int>();

            foreach (int element in treeElements)
            {
                tree.Add(element);
            }


            // Problem 2 - Range
            var range = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var elementsInRange = tree.Range(range[0], range[1]);
            Console.WriteLine(string.Join(" ", elementsInRange));

            // Problem 3 - Indexing
            //int index;
            //bool isIndex = int.TryParse(Console.ReadLine(), out index);
            //while (isIndex)
            //{
            //    try
            //    {
            //        Console.WriteLine(tree[index]);
            //    }
            //    catch (IndexOutOfRangeException)
            //    {
            //        Console.WriteLine("Invalid index");
            //    }

            //    isIndex = int.TryParse(Console.ReadLine(), out index);
            //}
        }
    }
}
