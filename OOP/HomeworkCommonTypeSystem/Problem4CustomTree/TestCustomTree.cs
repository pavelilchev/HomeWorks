
using System;

namespace Problem4CustomTree
{
	public class TestCustomTree
	{
		public static void Main(string[] args)
		{
			 CustomTree<int> tree =
            new CustomTree<int>(7,
                new CustomTree<int>(19,
                    new CustomTree<int>(1),
                    new CustomTree<int>(12),
                    new CustomTree<int>(31)),
                new CustomTree<int>(21),
                new CustomTree<int>(14,
                    new CustomTree<int>(23),
                    new CustomTree<int>(6))
            );
			
			 Console.WriteLine(tree);
			 
			 foreach (var element in tree)
			 {
			 	Console.WriteLine(element);
			 }
			Console.ReadKey(true);
		}
	}
}