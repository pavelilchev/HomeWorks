namespace Problem7ConnectedAreasInAMatrix
{
    using System;
    using System.Collections.Generic;

    public class ConnectedAreasTest
    {
        private static int rows;
        private static int cols;
        private static char[,] matrix;
        static bool[,]  isVisited;

        public static void Main()
        {
            //matrix = new[,]{
            //    { ' ', ' ', ' ', '*', ' ', ' ', ' ', '*', ' '},
            //    { ' ', ' ', ' ', '*', ' ', ' ', ' ', '*', ' '},
            //    { ' ', ' ', ' ', '*', ' ', ' ', ' ', '*', ' '},
            //    { ' ', ' ', ' ', ' ', '*', ' ', '*', ' ', ' '}
            //};

            matrix = new[,]{
                { '*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' '},
                { '*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' '},
                { '*', ' ', ' ', '*', '*', '*', '*', '*', ' ', ' '},
                { '*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' '},
                { '*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' '}
            };



            rows = matrix.GetLength(0);
            cols = matrix.GetLength(1);

            isVisited = new bool[rows, cols];
            var connectedAreas = new SortedSet<ConnectedArea>();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (!isVisited[i, j] && matrix[i, j] != '*')
                    {
                        var area = new ConnectedArea(i,j,0);
                        FindConnectedArea(i, j, area);
                        connectedAreas.Add(area);
                    }
                }
            }

            int counter = 1;
            Console.WriteLine("Total areas found: " + connectedAreas.Count);
            foreach (var arr in connectedAreas)
            {
                Console.WriteLine($"Area #{counter} at ({arr.X}, {arr.Y}), size: {arr.Size}");
            }
        }

        private static void FindConnectedArea(int row, int col, ConnectedArea area)
        {
            if (row < 0 || col < 0 || row >= rows || col >= cols)
            {
                return;
            }

            if (isVisited[row, col] || matrix[row, col] == '*')
            {
                return;
            }

            area.Size++;
            isVisited[row, col] = true;
            FindConnectedArea(row, col + 1, area);
            FindConnectedArea(row + 1, col, area);
            FindConnectedArea(row, col - 1, area);
            FindConnectedArea(row - 1, col, area);
        }
    }
}
