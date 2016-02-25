
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Problem4CustomTree
{
	public class CustomTree<T> : IEnumerable
	{
		private TreeNode<T> root;
		
		public CustomTree(T value)
		{
			this.root = new TreeNode<T>(value);
		}
		
		public CustomTree(T value, params CustomTree<T>[] children)
			: this(value)
		{
			foreach (CustomTree<T> child in children)
			{
				this.root.AddChild(child.root);
			}
		}
	
		public TreeNode<T> Root 
		{
			get 
			{
				return this.root;
			}
		}
		
		private string TravelTree(TreeNode<T> root, string spaces = "")
		{
			StringBuilder sb = new StringBuilder();
			
			if (this.root == null) 
			{
				return null;
			}
 
			sb.AppendLine(spaces + root.Value);
 
			TreeNode<T> child = null;
			
			for (int i = 0; i < root.ChildrenCount; i++) 
			{
				child = root.GetChild(i);
				sb.AppendLine(TravelTree(child, spaces + "   "));
			}
			
			return sb.ToString();
		}
		
		public override bool Equals(object obj)
		{
			CustomTree<T> other = obj as CustomTree<T>;
			
			if (other == null)
			{
				return false;
			}
			
			return this.ToString().Equals(other.ToString());
		}
		
		public override int GetHashCode()
		{
			int hashCode = this.ToString().GetHashCode();
		
			return hashCode;
		}
		
		public IEnumerator GetEnumerator()
		{
			var s = Travel(this.Root);
			
			foreach (var element in s)
			{
				yield return element;
			}
				}
		
		private Stack<T> Travel(TreeNode<T> parent)
		{			
			T result = parent.Value;
			Stack<T> results = new Stack<T>();
			results.Push(result);
			
			for (int i = 0; i < parent.ChildrenCount; i++)
			{
				results.Push(parent.GetChild(i).Value);
				Travel(parent.GetChild(i));
			}
			
			return results;
		}
		
		public override string ToString()
		{
			return this.TravelTree(this.Root);
		}
	}
}
