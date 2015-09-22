using System;


class LastDigitOfNumber
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        string lastDigit = GetLastDigitAsWord(number);

        Console.WriteLine(lastDigit);
    }

    private static string GetLastDigitAsWord(int number)
    {
        int lastDigit = number % 10;
        string lastDigitAsWord = string.Empty;

        switch (lastDigit)
        {
           case 0:
                lastDigitAsWord = "zero";
                break;
            case 1:
                lastDigitAsWord = "one";
                break;
            case 2:
                lastDigitAsWord = "two";
                break;
            case 3:
                lastDigitAsWord = "tree";
                break;
            case 4:
                lastDigitAsWord = "four";
                break;
            case 5:
                lastDigitAsWord = "five";
                break;
            case 6:
                lastDigitAsWord = "six";
                break;
            case 7:
                lastDigitAsWord = "seven";
                break;
            case 8:
                lastDigitAsWord = "eight";
                break;
            case 9:
                lastDigitAsWord = "nine";
                break;          
        }

        return lastDigitAsWord;
    }
}

