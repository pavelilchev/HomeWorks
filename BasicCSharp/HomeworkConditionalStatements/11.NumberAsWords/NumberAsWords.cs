using System;
class NumberAsWord
{
    static void Main()
    {
        Console.Write(" enter number [1..999]: ");
        int number = int.Parse(Console.ReadLine());
        if (number < 999 && number > 0)
        {
            switch (number / 100)
            {
                case 0: break;
                case 1: Console.Write(" One hundred "); break;
                case 2: Console.Write(" Two hundred "); break;
                case 3: Console.Write(" Tree hundred "); break;
                case 4: Console.Write(" Four hundred "); break;
                case 5: Console.Write(" Five hundred "); break;
                case 6: Console.Write(" Six hundred "); break;
                case 7: Console.Write(" Seven hundred "); break;
                case 8: Console.Write(" Eight hundred "); break;
                case 9: Console.Write(" nine hundred "); break;
                default: break;
            }
            if (number % 100 != 0 && number / 100 != 0)
            {
                Console.Write("and ");
            }
            switch (number / 10 % 10)
            {
                case 0: break;
                case 1:
                    switch (number % 10)
                    {
                        case 0: Console.Write("Ten "); break;
                        case 1: Console.Write("Eleven "); break;
                        case 2: Console.Write("Twelve "); break;
                        case 3: Console.Write("Thirteen "); break;
                        case 4: Console.Write("Fourteen "); break;
                        case 5: Console.Write("Fiveteen "); break;
                        case 6: Console.Write("Sixteen "); break;
                        case 7: Console.Write("Seventeen "); break;
                        case 8: Console.Write("Eighteen "); break;
                        case 9: Console.Write("Nineteen "); break;
                        default: break;
                    } break;
                case 2: Console.Write("Twenty "); break;
                case 3: Console.Write("Thirty "); break;
                case 4: Console.Write("Forty "); break;
                case 5: Console.Write("Fifty "); break;
                case 6: Console.Write("Sixty "); break;
                case 7: Console.Write("Seventy "); break;
                case 8: Console.Write("Eighty "); break;
                case 9: Console.Write("Ninety "); break;
                default: break;
            }
            switch (number % 10)
            {
                case 0: if (number == 0)
                    {
                        Console.Write("zero");
                    }
                    Console.Write("\n "); break;
                case 1: if (number / 10 % 10 == 1) break;
                    Console.WriteLine("One"); break;
                case 2: if (number / 10 % 10 == 1) break;
                    Console.WriteLine("Two"); break;
                case 3: if (number / 10 % 10 == 1) break;
                    Console.WriteLine("Three "); break;
                case 4: if (number / 10 % 10 == 1) break;
                    Console.WriteLine("Four"); break;
                case 5: if (number / 10 % 10 == 1) break;
                    Console.WriteLine("Five"); break;
                case 6: if (number / 10 % 10 == 1) break;
                    Console.WriteLine("Six"); break;
                case 7: if (number / 10 % 10 == 1) break;
                    Console.WriteLine("Seven"); break;
                case 8: if (number / 10 % 10 == 1) break;
                    Console.WriteLine("Eight"); break;
                case 9: if (number / 10 % 10 == 1) break;
                    if (number / 10 % 10 == 1) break;
                    Console.WriteLine("nine"); break;
                default: break;
            }
        }
        else Console.WriteLine(" Out of range! ");
    }
}