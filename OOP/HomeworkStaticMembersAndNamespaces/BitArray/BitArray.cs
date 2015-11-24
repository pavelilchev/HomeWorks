using System;
using System.Numerics;

namespace BitArray
{
    public class BitArray
    {
        private int bits;
        private byte[] number;

        public BitArray(int bits)
        {
            this.Bits = bits;
            number = new byte[this.Bits];
        }

        public int Bits
        {
            get { return this.bits; }
            set
            {
                if (value < 1 || value > 100000)
                {
                    throw new ArgumentException("Number of bits shold be in range 1..100 000");
                }

                this.bits = value;
            }
        }

        public byte this[int index]
        {
            get
            {
                if (index < 0 || index > this.Bits - 1)
                {
                    throw new IndexOutOfRangeException(string.Format("Index should be in range [{0}..{1}]", 0, this.Bits - 1));
                }

                return number[index];
            }
            set
            {
                if (value != 0 && value != 1)
                {
                    throw new ArgumentException("Bit can be 0 or 1");
                }

                if (index < 0 || index > this.Bits - 1)
                {
                    throw new IndexOutOfRangeException(string.Format("Index should be in range [{0}..{1}]", 0, this.Bits - 1));
                }

                this.number[index] = value;
            }
        }

        public override string ToString()
        {
            BigInteger multy = 2;
            BigInteger result = 0;

            for (int i = 0; i < this.Bits; i++)
            {
                result += this.number[i] * Power(2,i);
            }
            return result.ToString();
        }

        public static BigInteger Power(BigInteger b1, BigInteger b2)
        {
            BigInteger result = 1;

            for (BigInteger i = 0; i < b2; i++)
            {
                result *= b1;
            }

            return result;
        }
    }
}
