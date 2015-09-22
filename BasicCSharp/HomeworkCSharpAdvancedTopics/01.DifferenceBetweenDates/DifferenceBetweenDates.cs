using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.DifferenceBetweenDates
{
    class DifferenceBetweenDates
    {
        static void Main(string[] args)
        {

            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();
            string[] firstSplit = firstDate.Split('.');
            string[] secondSplit = secondDate.Split('.');
            DateTime first = new DateTime(Convert.ToInt32(firstSplit[2]), 
                                          Convert.ToInt32(firstSplit[1]),
                                          Convert.ToInt32(firstSplit[0]));
            DateTime second = new DateTime(Convert.ToInt32(secondSplit[2]),
                                          Convert.ToInt32(secondSplit[1]),
                                          Convert.ToInt32(secondSplit[0]));
            Console.WriteLine((second-first).TotalDays);
           
        }
    }
}
