namespace Point3D
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    [Serializable]
    public class Path3D
    {
        private List<Point3D> path;

        public Path3D()
        {
            path = new List<Point3D>();
        }

        public List<Point3D> Path
        {
            get
            {
                return this.path;
            }
        }

        public void AddPoint3DToPath(Point3D point)
        {
            this.path.Add(point);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("Path:");           
           
            foreach (var point in this.Path)
            {
                sb.Append(Environment.NewLine);
                sb.Append(point);               
            }

            return sb.ToString();
        }
    }
}
