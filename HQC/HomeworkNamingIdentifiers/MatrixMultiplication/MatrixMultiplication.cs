namespace MatrixMultiplication
{
    using System;

    public static class MatrixMultiplication
    {
        public static void Main()
        {
            var matrixOne = new double[,] { { 1, 3 }, { 5, 7 } };
            var matrixTwo = new double[,] { { 4, 2 }, { 1, 5 } };
            var resultMatrix = MultiplyMatrix(matrixOne, matrixTwo);

            PrintMatrix(resultMatrix);
        }

        private static void PrintMatrix(double[,] resultMatrix)
        {
            for (int row = 0; row < resultMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < resultMatrix.GetLength(1); col++)
                {
                    Console.Write("{0, 3}", resultMatrix[row, col]);
                }

                Console.WriteLine();
            }
        }
      
        private static double[,] MultiplyMatrix(double[,] firstMatrix, double[,] secondMatrix)
        {
            if (firstMatrix.GetLength(1) != secondMatrix.GetLength(0))
            {
                throw new Exception("Matrices can't be multiplied.");
            }

            int firstMatrixCol = firstMatrix.GetLength(1);
            var resultMatrix = new double[firstMatrix.GetLength(0), secondMatrix.GetLength(1)];

            for (int row = 0; row < resultMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < resultMatrix.GetLength(1); col++)
                {
                    for (int i = 0; i < firstMatrixCol; i++)
                    {
                        resultMatrix[row, col] += firstMatrix[row, i] * secondMatrix[i, col];
                    }
                }
            }

            return resultMatrix;
        }
    }
}