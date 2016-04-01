namespace Problem2TraverseAndSaveDirectoryContentsInTree
{
    using System.Collections.Generic;

    public class Folder
    {
        public Folder(string name, string fullPath)
        {
            this.Name = name;
            this.FullPath = fullPath;
            this.Files = new List<File>();
            this.Folders = new List<Folder>();
        }

        public string Name { get; set; }

        public string FullPath { get; set; }

        public List<File> Files { get; set; }

        public List<Folder> Folders { get; set; }
    }
}
