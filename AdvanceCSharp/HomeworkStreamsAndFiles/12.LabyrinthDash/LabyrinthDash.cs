using System;

class LabyrinthDash
{
    static void Main()
    {
        const string ObstacleCharacters = "@#*";

        int numberOfRows = int.Parse(Console.ReadLine());
        char[][] matrix = new char[numberOfRows][];

        for (int i = 0; i < numberOfRows; i++)
        {
            matrix[i] = Console.ReadLine().ToCharArray();
        }

        int lives = 3;
        int movesMade = 0;
        int row = 0;
        int col = 0;

        string commands = Console.ReadLine();

        foreach (var direction in commands)
        {
            int previousRow = row;
            int previousCol = col;
            switch (direction)
            {
                case '<': col--; break;
                case '>': col++; break;
                case 'v': row++; break;
                case '^': row--; break;
            }
            if (!IsCellInsideMatrix(row, col, matrix) || matrix[row][col] == ' ')
            {
                Console.WriteLine("Fell off a cliff! Game Over!");
                movesMade++;
                break;
            }
            else if (matrix[row][col] == '_' || matrix[row][col] == '|')
            {
                Console.WriteLine("Bumped a wall.");
                row = previousRow;
                col = previousCol;
            }
            else if (ObstacleCharacters.Contains(matrix[row][col].ToString()))
            {
                Console.WriteLine("Ouch! That hurt! Lives left: {0}", --lives);
                movesMade++;

                if (lives <= 0)
                {
                    Console.WriteLine("No lives left! Game Over!");
                    break;
                }
            }
            else if (matrix[row][col] == '$')
            {
                lives++;
                movesMade++;
                matrix[row][col] = '.';
                Console.WriteLine("Awesome! Lives left: {0}", lives);
            }
            else
            {
                movesMade++;
                Console.WriteLine("Made a move!");
            }

            char currentCell = matrix[row][col];
        }

        Console.WriteLine("Total moves made: {0}", movesMade);
    }

    private static bool IsCellInsideMatrix(int row, int col, char[][] matrix)
    {
        bool isRowInsideMatrix = 0 <= row && row < matrix.Length;
        if (!isRowInsideMatrix)
        {
            return false;
        }

        return isRowInsideMatrix;
    }
}