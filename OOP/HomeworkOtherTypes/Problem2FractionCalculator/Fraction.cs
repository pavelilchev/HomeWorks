
using System;

namespace Problem2FractionCalculator
{
    public struct Fraction
    {
        private long numerator;
        private long denominator;

        public Fraction(long numerator, long denominator) : this()
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        public long Numerator
        {
            get { return this.numerator; }
            set { this.numerator = value; }
        }

        public long Denominator
        {
            get { return this.denominator; }
            set
            {
                if (value == 0)
                {
                    throw new ArithmeticException("Zero devided isn't possible");
                }
                this.denominator = value;
            }
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            long newDenominator = a.Denominator * b.Denominator;
            long aNumerator = a.Numerator * b.Denominator;
            long bNumerator = b.Numerator * a.Denominator;
            return new Fraction(aNumerator + bNumerator, newDenominator);
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            long newDenominator = a.Denominator * b.Denominator;
            long aNumerator = a.Numerator * b.Denominator;
            long bNumerator = b.Numerator * a.Denominator;
            return new Fraction(aNumerator - bNumerator, newDenominator);
        }

        public override string ToString()
        {
            return (this.Numerator / (decimal)this.Denominator).ToString();
        }

    }
}
