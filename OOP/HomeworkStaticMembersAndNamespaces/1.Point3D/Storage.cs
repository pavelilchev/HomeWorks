namespace Point3D
{
    using System.IO;
    using System.Collections.Generic;

    public static class Storage
    {
        public static void SavePath(Path3D path)
        {
            string file = "../../save.bin";

            using (Stream stream = File.Open(file, FileMode.Create))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                bformatter.Serialize(stream, path.Path);
            }
        }

        public static Path3D LoadPath()
        {
            string file = "../../save.bin";
            using (Stream stream = File.Open(file, FileMode.Open))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                List<Point3D> loadedPath = (List<Point3D>)bformatter.Deserialize(stream);

                Path3D path = new Path3D();
                foreach (var loadP in loadedPath)
                {
                    path.AddPoint3DToPath(loadP);
                }

                return path;
            }
        }
    }
}
