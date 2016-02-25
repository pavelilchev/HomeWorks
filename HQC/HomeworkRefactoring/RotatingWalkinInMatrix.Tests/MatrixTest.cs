namespace RotatingWalkinInMatrix.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MatrixTest
    {
        [TestMethod]
        public void TestGenerateMatrix_WhitDimensionOne()
        {
            var matrix = new Matrix(1);
            var actualMatrix = matrix.GenerateMatrix();
            var expectedMatrix = new int[1, 1];
            expectedMatrix[0, 0] = 1;
            CollectionAssert.AreEqual(expectedMatrix, actualMatrix);
        }

        [TestMethod]
        public void TestGenerateMatrix_WhitDimensionThree()
        {
            var matrix = new Matrix(3);
            var actualMatrix = matrix.GenerateMatrix();
            int[,] expectedMatrix =
            {
                {1, 7, 8},
                {6, 2, 9},
                {5, 4, 3}
            };
            expectedMatrix[0, 0] = 1;
            CollectionAssert.AreEqual(expectedMatrix, actualMatrix);
        }

        [TestMethod]
        public void TestGenerateMatrix_WhitDimensionSix()
        {
            var matrix = new Matrix(6);
            var actualMatrix = matrix.GenerateMatrix();
            int[,] expectedMatrix =
            {
                {1, 16, 17, 18, 19, 20},
                {15,  2, 27, 28, 29, 21},
                {14, 31,  3, 26, 30, 22},
                {13, 36, 32,  4, 25, 23 },
                {12, 35, 34, 33,  5, 24 },
                {11, 10, 9,  8,  7,  6 }
            };
            expectedMatrix[0, 0] = 1;
            CollectionAssert.AreEqual(expectedMatrix, actualMatrix);
        }
    }
}
