using System;
using System.Text;

class ReverseString
{
    static void Main()
    {
        string input = Console.ReadLine();
        string reversed = Reverse(input);
        Console.WriteLine(reversed);
    }

    private static string Reverse(string input)
    {
        StringBuilder sb = new StringBuilder();
        int count = input.Length;

        for (int i = count - 1; i >= 0; i--)
        {
            sb.Append(input[i]);
        }

        return sb.ToString();
    }
}

