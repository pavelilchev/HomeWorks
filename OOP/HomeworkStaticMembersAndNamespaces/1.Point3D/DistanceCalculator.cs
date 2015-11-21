namespace Point3D
{
    using System;

    public static class DistanceCalculator
    {
        public static double CalculateDistanceBetween3DPoints(Point3D first, Point3D second)
        {
            double xDistance = Math.Pow((second.X - first.X), (second.X - first.X));
            double yDistance = Math.Pow((second.Y - first.Y), (second.Y - first.Y));
            double zDistance = Math.Pow((second.Z - first.Z), (second.Z - first.Z));
            double distance = Math.Sqrt(xDistance + yDistance + zDistance);

            return distance;
        }
    }
}
