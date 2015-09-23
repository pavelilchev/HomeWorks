using System;
using System.Text;


class UnicodeCharacters
{
    static void Main()
    {
        string input = Console.ReadLine();

        StringBuilder sb = new StringBuilder();

        foreach (var item in input)
        {
            int decimalChar = (int)item;           
            string charToUnicode = "\\" + "u" + string.Format("{0}", decimalChar.ToString("X4"));

            sb.Append(charToUnicode);
        }
       
        Console.WriteLine(sb);
    }
}

