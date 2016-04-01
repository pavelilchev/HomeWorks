namespace Problem2TraverseAndSaveDirectoryContentsInTree
{
    using System;
    using System.IO;

    public static class TraversAndSaveDirectory
    {
        public static void Main()
        {
            string rootDirectory = @"C:\WINDOWS";
            var rootFolder = new Folder("WINDOWS", rootDirectory);
            TraversDirectory(rootFolder);
            PrintDirectories(rootFolder, 0);
        }

        private static void PrintDirectories(Folder rootFolder, int indent)
        {
            Console.Write(new string(' ', 2 * indent));
            Console.WriteLine(rootFolder.Name);

            foreach (var file in rootFolder.Files)
            {
                Console.Write(new string(' ', 2 * (indent + 1)));
                Console.WriteLine(file.Name + " " + "Size: " + file.Size + " bytes");
            }

            foreach (var folder in rootFolder.Folders)
            {
                PrintDirectories(folder, indent + 1);
            }
        }

        private static void TraversDirectory(Folder folder)
        {
            var directoryInfo = new DirectoryInfo(folder.FullPath);
            var files = directoryInfo.GetFiles();
            var directories = directoryInfo.GetDirectories();

            TraversFiles(folder, files);
            
            foreach (var directory in directories)
            {
                var currentFolder = new Folder(directory.Name, directory.FullName);
                folder.Folders.Add(currentFolder);

                try
                {
                    TraversDirectory(currentFolder);
                }
                catch (UnauthorizedAccessException)
                {
                }
            }
        }

        private static void TraversFiles(Folder folder, FileInfo[] files)
        {
            foreach (var file in files)
            {
                folder.Files.Add(new File(file.Name, file.Length));
            }
        }
    }
}
