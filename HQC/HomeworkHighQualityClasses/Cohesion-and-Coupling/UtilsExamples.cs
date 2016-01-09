namespace CohesionAndCoupling
{
    using System;

    public static class UtilsExamples
    {
        public static void Main()
        {
            try
            {
                Console.WriteLine(FileUtils.GetFileExtension("example.pdf"));
                Console.WriteLine(FileUtils.GetFileExtension("example.new.pdf"));
               
                Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.pdf"));
                Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.new.pdf"));

                Console.WriteLine(FileUtils.GetFileExtension("example"));
                Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example"));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
            }

            Console.WriteLine("Distance in the 2D space = {0:f2}", Figure3DUtils.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}", Figure3DUtils.CalcDistance3D(5, 2, -1, 3, -6, 4));

            IFigure3D figure = new Figure3D(3, 4, 5);
         
            Console.WriteLine("Volume = {0:f2}", Figure3DUtils.CalcVolume(figure));
            Console.WriteLine("Diagonal XYZ = {0:f2}", Figure3DUtils.CalcDiagonalXYZ(figure));
            Console.WriteLine("Diagonal XY = {0:f2}", Figure3DUtils.CalcDiagonalXY(figure));
            Console.WriteLine("Diagonal XZ = {0:f2}", Figure3DUtils.CalcDiagonalXZ(figure));
            Console.WriteLine("Diagonal YZ = {0:f2}", Figure3DUtils.CalcDiagonalYZ(figure));
        }
    }
}
