using System;
using System.Text;

class DecimalToBinaryNumber
{
    static void Main()
    {
        long number = long.Parse(Console.ReadLine());
        long bit;
        StringBuilder binary = new StringBuilder();
        while (number > 0) 
        {
            bit = number % 2;
            number /= 2;
            binary.Append(bit);
        }
        char[] array = (binary.ToString()).ToCharArray();
        Array.Reverse(array);
        new String(array);
        Console.WriteLine(array);
    }
}

