namespace Problem6PathsBetweenCellsInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Labyrinth
    {
        private char[,] labyrinth;
        private int pathsFound;
        private List<string> paths;
        private int rows;
        private int cols;

        public Labyrinth(char[,] labyrinth)
        {
            this.labyrinth = labyrinth;
            this.pathsFound = 0;
            this.paths = new List<string>();
            this.rows = labyrinth.GetLength(0);
            this.cols = labyrinth.GetLength(1);
        }

        public void PrintPaths()
        {
            this.FindPaths();

            if (this.pathsFound == 0)
            {
                Console.WriteLine("No path found");
            }
            else
            {
                foreach (string path in this.paths)
                {
                    Console.WriteLine(path);
                }

                Console.WriteLine("Total paths found: " + this.pathsFound);
            }
        }

        private void FindPaths()
        {
            int startRow = -1;
            int startCol = -1;
            bool hasStart = false;
            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.cols; j++)
                {
                    if (this.labyrinth[i, j] == 's')
                    {
                        startRow = i;
                        startCol = j;
                        hasStart = true;
                        break;
                    }
                }

                if (hasStart)
                {
                    break;
                }
            }

            if (!hasStart)
            {
                throw new InvalidOperationException("Labyrinth dont have a entry point.");
            }

            var path = new List<char>();
            this.labyrinth[startRow, startCol] = ' ';
            this.TryPath(startRow, startCol, path, 'S');
            this.labyrinth[startRow, startCol] = 's';
        }

        private void TryPath(int row, int col, List<char> path, char destination)
        {
            if (row < 0 || col < 0 || row >= this.rows || col >= this.cols )
            {
                return;
            }

            if (this.labyrinth[row, col] == 'e')
            {
                path.Add(destination);
                this.paths.Add(string.Join("", path.Skip(1)));
                this.pathsFound++;
                path.RemoveAt(path.Count - 1);
                return;
            }

            if (this.labyrinth[row,col] != ' ')
            {
                return;
            }

            path.Add(destination);
            this.labyrinth[row, col] = 's';
            this.TryPath(row, col + 1, path, 'R');
            this.TryPath(row + 1, col, path, 'D');
            this.TryPath(row, col - 1, path, 'L');
            this.TryPath(row - 1, col, path, 'U');
            this.labyrinth[row, col] = ' ';
            path.RemoveAt(path.Count - 1);
        }
    }
}
