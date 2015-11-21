using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class OddLines
{
    static void Main()
    {
        StreamReader reader = new StreamReader(@"..\..\text.txt");

        using (reader)
        {
            int lineCounter = 0;
            string line = reader.ReadLine();

            while (line != null)
            {
                if (lineCounter % 2 != 0)
                {
                    Console.WriteLine(line);    
                }

                line = reader.ReadLine();
                lineCounter++;
            }
        }
    }
}

