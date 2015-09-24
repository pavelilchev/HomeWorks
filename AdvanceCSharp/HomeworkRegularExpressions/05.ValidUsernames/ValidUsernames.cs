using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class ValidUsernames
{
    static void Main()
    {
        string usernameList = Console.ReadLine();

        char[] delimeters = {' ', '/', '\\', '(', ')' };
        string[] splitUsernames = usernameList.Split(delimeters, StringSplitOptions.RemoveEmptyEntries);
        string pattern = @"\b([a-z][\w]{2,24})\b";
        Regex reg = new Regex(pattern);
        List<string> validUserNames = new List<string>();
        foreach (var item in splitUsernames)
        {
            if (reg.IsMatch(item))
            {
                validUserNames.Add(item);
            }
        }

        int index = 0;
        int maxLenght = 0;

        for (int i = 0; i < validUserNames.Count - 1; i++)
        {
            int sumlenght = validUserNames[i].Length + validUserNames[i + 1].Length;
            if (sumlenght > maxLenght)
            {
                maxLenght = sumlenght;
                index = i;
            }
        }

        Console.WriteLine(validUserNames[index]);
        Console.WriteLine(validUserNames[index+1]);
    }
}

