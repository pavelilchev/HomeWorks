using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class LineNumbers
{
    static void Main()
    {
        StreamReader raider = new StreamReader(@"..\..\text.txt");
        StreamWriter writer = new StreamWriter(@"..\..\result.txt");
        int counter = 1;

        using (raider)
        {
            using (writer)
            {
                string line = raider.ReadLine();

                while (line != null)
                {
                    
                    writer.WriteLine("Line {0}: {1}", counter, line);
                    line = raider.ReadLine();
                    counter++;
                }
            }
        }
    }
}

