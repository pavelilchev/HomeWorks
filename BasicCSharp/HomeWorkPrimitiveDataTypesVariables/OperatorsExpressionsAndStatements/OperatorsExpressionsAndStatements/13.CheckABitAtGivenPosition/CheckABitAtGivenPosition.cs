using System;

    class CheckABitAtGivenPosition
    {
        static void Main()
        {
            Console.WriteLine("Enter number:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter position:");
            int p = int.Parse(Console.ReadLine());
            bool isBit1 = false;
            int mask = 1 << p;
            if ((mask & n) == mask)
            {
                isBit1 = true;
            }
            Console.WriteLine(isBit1);
        }
    }

