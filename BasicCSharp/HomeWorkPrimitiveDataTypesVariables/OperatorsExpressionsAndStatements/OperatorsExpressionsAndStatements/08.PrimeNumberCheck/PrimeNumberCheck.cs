using System;

    class PrimeNumberCheck
    {
        static void Main()
        {
            Console.WriteLine("Enter number:");
            int n = int.Parse(Console.ReadLine());

            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                {
                    Console.WriteLine(false);
                }               
            }
        }
    }

