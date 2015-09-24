using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class QueryMess
{
    static void Main()
    {
        string input = Console.ReadLine();
        StringBuilder sb = new StringBuilder();
        Dictionary<string, List<string>> output = new Dictionary<string, List<string>>();

        while (input != "END")
        {
            sb.Append(input);
            sb.Replace("+", "");
            sb.Replace("%20", "");
            string[] pair = sb.ToString().Split('&', '?');
            string[] splitedPair;

            foreach (var par in pair)
            {
                if (!par.Contains("="))
                {
                    continue;                   
                }

                splitedPair = par.ToString().Split('=');

                if (!output.ContainsKey(splitedPair[0]))
                {
                    output.Add(splitedPair[0], new List<string>());
                }

                output[splitedPair[0]].Add(splitedPair[1]);
            }

            foreach (var item in output)
            {
                Console.Write(item.Key + "=" + "[" + string.Join(", ", item.Value) + "]");
            }

            Console.WriteLine();
            sb.Clear();
            output.Clear();
            input = Console.ReadLine();            
        }       
    }
}

