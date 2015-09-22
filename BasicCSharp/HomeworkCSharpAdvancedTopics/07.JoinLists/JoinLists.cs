using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.JoinLists
{
    class JoinLists
    {
        static void Main(string[] args)
        {
            string[] firstInput = Console.ReadLine().Split(' ');
            string[] secondInput = Console.ReadLine().Split(' ');
            List<int> first = new List<int>();
            List<int> second = new List<int>();
           

            for (int i = 0; i < firstInput.Length; i++)
            {
                first.Add(int.Parse(firstInput[i]));
            }
            for (int i = 0; i < secondInput.Length; i++)
            {
                second.Add(int.Parse(secondInput[i]));
            }

            var result = first.Concat(second);
            List<int> resultList = result.ToList();

            resultList.Sort();
            int index = 0;
            while (index < resultList.Count - 1)
            {
                if (resultList[index] == resultList[index + 1])
                    resultList.RemoveAt(index);
                else
                    index++;
            }
            foreach (var item in resultList)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
