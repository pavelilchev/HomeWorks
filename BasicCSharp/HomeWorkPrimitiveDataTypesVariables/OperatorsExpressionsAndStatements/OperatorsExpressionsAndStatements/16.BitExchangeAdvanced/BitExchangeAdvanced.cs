using System;

class BitExchangeAdvanced
{
    static void Main(string[] args)
    {
        uint n;
        byte p, q, k;
        Console.Write("Enter the unsigned integer number n:");
        bool isnInt = uint.TryParse(Console.ReadLine(), out n);
        Console.Write("Enter the start position of the first bit sequence p:");
        bool ispByte = byte.TryParse(Console.ReadLine(), out p);
        Console.Write("Enter the start position of the second bit sequence q:");
        bool isqByte = byte.TryParse(Console.ReadLine(), out q);
        Console.Write("Enter the lenght of the sequence k:");
        bool iskByte = byte.TryParse(Console.ReadLine(), out k);

        if (isnInt & ispByte & isqByte & iskByte)
        {
            if ((p + k) < 32 && (q + k) < 32)
            {
                if ((Math.Abs(p - q) >= k))
                {
                    if (p > q)
                    {
                        byte temp = q;
                        q = p;
                        p = temp;
                    }
                    Console.WriteLine("binary initial n:");
                    Console.WriteLine(Convert.ToString(n, 2).PadLeft(32, '0'));

                    n = ((~(((uint)Math.Pow(2, k) - 1) << q | ((uint)Math.Pow(2, k) - 1) << p)) & n) | (((n & (((uint)Math.Pow(2, k) - 1) << p)) << (Math.Abs(p - q))) | ((n & (((uint)Math.Pow(2, k) - 1) << q)) >> (Math.Abs(p - q))));//Swap bits p with bits q
                    Console.WriteLine("binary new n:");
                    Console.WriteLine(Convert.ToString(n, 2).PadLeft(32, '0'));
                    Console.WriteLine(n);
                }
                else
                {
                    Console.WriteLine("overlapping");
                }

            }
            else
            {
                Console.WriteLine("out of range");
            }
        }
        else
        {
            Console.WriteLine("Not valid number");
        }
    }
}



