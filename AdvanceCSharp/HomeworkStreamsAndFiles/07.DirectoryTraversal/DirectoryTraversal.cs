﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


internal class DirectoryTraversal
{
    private static void Main()
    {
        string[] filePaths = Directory.GetFiles(@"../../");

        List<FileInfo> files = filePaths.Select(path => new FileInfo(path)).ToList();

        var sorted =
            files.OrderBy(file => file.Length).GroupBy(file => file.Extension).OrderByDescending(group => group.Count()).ThenBy(group => group.Key);
    
        string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        StreamWriter writer = new StreamWriter(desktop + "/report.txt");

        using (writer)
        {
            foreach (var group in sorted)
            {
                writer.WriteLine(group.Key);

                foreach (var y in group)
                {
                    writer.WriteLine("--{0} - {1:F3}kb", y.Name, y.Length / 1024.0);
                }
            } 
        }       

        System.Diagnostics.Process.Start(desktop + "/report.txt");
    }
}
