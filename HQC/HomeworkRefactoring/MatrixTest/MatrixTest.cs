namespace MatrixTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RotatingWalkinInMatrix;
    using RotatingWalkinInMatrix.IO;

    [TestClass]
    public class MatrixTest
    {
        [TestMethod]
        public void TestGenerateMatrix_InputOne()
        {
            IUserInterface userInterface = new ConsoleUserInterface();
            Matrix matrix = new Matrix(userInterface);
            var actualMatrix = matrix.GenerateMatrix();
            var expectedMatrix = new int[1, 1];
            expectedMatrix[0, 0] = 1;
            CollectionAssert.AreEqual(expectedMatrix, actualMatrix);
        }
    }
}
