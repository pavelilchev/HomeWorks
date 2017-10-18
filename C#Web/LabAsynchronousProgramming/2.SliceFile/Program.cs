using System;
using System.IO;
using System.Threading.Tasks;

namespace _2.SliceFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = Console.ReadLine();
            var destinationFolderName = Console.ReadLine();
            var piecesCount = int.Parse(Console.ReadLine());

            SliceAsync(fileName, destinationFolderName, piecesCount);

            Console.WriteLine("Now what?");
            while (true)
            {
                var line = Console.ReadLine();
                if (line == "exit")
                {
                    break;
                }
            }
        }

        static void SliceAsync(string sourceFile, string destinationPath, int parts)
        {
            Task.Run(() =>
            {
                Slice(sourceFile, destinationPath, parts);
            });
        }

        static void Slice(string fileName, string destination, int parts)
        {
            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }

            using (var source = new FileStream(fileName, FileMode.Open))
            {
                var fileInfo = new FileInfo(fileName);
                var partLenght = (source.Length / parts) + 1;
                var currentByte = 0;

                for (int i = 1; i <= parts; i++)
                {
                    string filePath = string.Format("{0}/Part-{1}{2}", destination, i, fileInfo.Extension);

                    using (var dest = new FileStream(filePath, FileMode.Create))
                    {
                        byte[] buffer = new byte[1024];
                        while (currentByte <= partLenght * i)
                        {
                            int readBytesCount = source.Read(buffer, 0, buffer.Length);
                            if (readBytesCount == 0)
                            {
                                break;
                            }

                            dest.Write(buffer, 0, readBytesCount);
                            currentByte += readBytesCount;
                        }
                    }
                }
            }

            Console.WriteLine("Slice complete");
        }
    }
}
