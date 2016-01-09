using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

public class Program
{
	public static void Main()
	{
		int[] matrixSize = Console.ReadLine().Split().Select(a => int.Parse(a)).ToArray();
		int n = matrixSize[0];
		int m = matrixSize[1];
		string snake = Console.ReadLine();
		int[] shootParameters = Console.ReadLine().Split().Select(a => int.Parse(a)).ToArray();
		int shootRow = shootParameters[0];
		int shootCol = shootParameters[1];
		int shootRadius = shootParameters[2];
		char[,] matrix = new char[n, m];	
		
		int r = n -1;
		int c = m - 1;
		int k = 0;
		string comand = "left";
		while (true)
		{
			if (comand == "left")
			{
				if (c >= 0)
				{
					matrix[r, c] = snake[k % snake.Length];
					c--;	
					k++;
				}
				else
				{
					c++;
					r--;
					comand = "right";
				}
			}
			if (comand == "right")
			{
				if(c < m)
				{
					matrix[r, c] = snake[k % snake.Length];
					c++;
					k++;
				}
				else
				{
					c--;
					r--;
					comand = "left";
				}
			}
			
			if (k >= m*n)
			{
				break;
			}
		}
		
		int minRow = Math.Max(0, shootRow - shootRadius);								//0
		int maxRow = Math.Min(matrix.GetLength(0) - 1, shootRow +  shootRadius);		//4
		int minCol = Math.Max(0, shootCol - shootRadius);								//1
		int maxCol = Math.Min(matrix.GetLength(1) - 1, shootCol + shootRadius);			//5
		int high = Math.Abs(minRow - shootRadius);
		for (int i = minRow; i <= maxRow; i++)
		{
			for (int j = minCol; j <= maxCol; j++)
			{
				if (Math.Abs(i - shootRow)*Math.Abs(i - shootRow) + Math.Abs(j- shootCol)*
					Math.Abs(j- shootCol) <= shootRadius*shootRadius)
				{
					matrix[i, j] = ' '; 
				}
			}
		}
		List<char> result = new List<char>();
		
		for (int col = 0; col < m; col++)
		{
			for (int row = n - 1; row >= 1; row--)
			{
				result.Add(matrix[row, col]);
			}
			result.Add(matrix[0, col]);
			result.RemoveAll(item => item == ' ');
			int index = 0;
			for (int row = n - 1; row >= 0; row--)
			{
				if (index < result.Count())
				{
					matrix[row, col] = result[index];
					index++;
				}
				else
				{
					matrix[row, col] = ' ';
				}				
			}
			result.Clear();			
		}		
		for (int i = 0; i < n; i++)
		{
			for (int j = 0; j < m; j++)
			{
				Console.Write(matrix[i, j]);
			}
			Console.WriteLine();
		}
	}	
}	
