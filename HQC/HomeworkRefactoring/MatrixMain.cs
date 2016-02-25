namespace RotatingWalkinInMatrix
{
    using IO;

    public static class MatrixMain
    {
        public static void Main()
        {
            IUserInterface userInterface = new ConsoleUserInterface();
            int dimension = TakeMatrixDimension(userInterface);
            var matrixWalk = new Matrix(dimension);

            var matrix = matrixWalk.GenerateMatrix();

            PrintMatrix(matrix, userInterface);
        }

        private static int TakeMatrixDimension(IUserInterface userInterface)
        {
            userInterface.WriteLine("Enter a positive number ");
            string input = userInterface.ReadLine();

            int number;
            bool isParsed = int.TryParse(input, out number);

            while (!isParsed || number < 0 || number > 100)
            {
                userInterface.WriteLine("You haven't entered a correct positive number");
                input = userInterface.ReadLine();
                isParsed = int.TryParse(input, out number);
            }

            return number;
        }

        private static void PrintMatrix(int[,] matrix, IUserInterface userInterface)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    userInterface.Write("{0,3}", matrix[row, col]);
                }

                userInterface.WriteLine();
            }
        }
    }
}
