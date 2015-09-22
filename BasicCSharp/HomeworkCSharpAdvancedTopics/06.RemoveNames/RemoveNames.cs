using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.RemoveNames
{
    class RemoveNames
    {
        static void Main(string[] args)
        {
            string[] firstInput = Console.ReadLine().Split(' ');
            string[] secondInput = Console.ReadLine().Split(' ');
            List<string> first = new List<string>();
            List<string> second = new List<string>();
            for (int i = 0; i < firstInput.Length; i++)
            {
                first.Add(firstInput[i]);
            }
            for (int i = 0; i < secondInput.Length; i++)
            {
                second.Add(secondInput[i]);
            }

            List<string> remove = new List<string>();
            for (int j = 0; j < second.Count; j++)
            {
                for (int i = 0; i < first.Count; i++)
                {
                    if (second[j] == firstInput[i])
                    {
                        remove.Add(second[j]);
                    }
                } 
            }
            int indexLenght = remove.Count;
            for (int i = 1; i <= indexLenght; i++)
            {
                first.Remove(remove[indexLenght-i]);
            }
            foreach (var item in first)
            {
                Console.Write(item + " ");
            }
        }
    }
}
