using System;
using System.Text;

class DecimalToHexadecimalNumber
{
    static void Main()
    {
        long number = long.Parse(Console.ReadLine());
        long bit;
        StringBuilder binary = new StringBuilder();
        while (number > 0)
        {
            bit = number % 16;
            number /= 16;
            switch (bit)
            {
                case 10: binary.Append('A'); break;
                case 11: binary.Append('B'); break;
                case 12: binary.Append('C'); break;
                case 13: binary.Append('D'); break;
                case 14: binary.Append('E'); break;
                case 15: binary.Append('F'); break;
                default: binary.Append(bit); break;
            }
        }
        char[] array = (binary.ToString()).ToCharArray();
        Array.Reverse(array);
        new String(array);
        Console.WriteLine(array);
    }
}

