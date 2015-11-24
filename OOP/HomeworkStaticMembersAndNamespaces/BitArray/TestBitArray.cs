using System;

namespace BitArray
{
    class TestBitArray
    {
        static void Main(string[] args)
        {
            BitArray bits = new BitArray(1000);
            bits[999] = 1;
            Console.WriteLine(bits);
        }
    }
}
