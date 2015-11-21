namespace Point3D
{
    using System;

    class TestPoint
    {
        public static void Main(string[] args)
        {
            Point3D p1 = new Point3D(1.1, 2.2, 3.3);
            Point3D p2 = new Point3D(2.1, 3.2, 4.3);
            Console.WriteLine(p1);
            Console.WriteLine(p2);
            Console.WriteLine("Zero point: " + Point3D.StartingPoint);

           double distance = DistanceCalculator.CalculateDistanceBetween3DPoints(p1, p2);
            Console.WriteLine("Distance is: " + distance);

            Path3D myPath = new Path3D();
            myPath.AddPoint3DToPath(p1);
            myPath.AddPoint3DToPath(p2);
            Console.WriteLine(myPath);
            
            Storage.SavePath(myPath);
            Path3D loadedPath = Storage.LoadPath();
            Console.WriteLine(loadedPath);
        }
    }
}
