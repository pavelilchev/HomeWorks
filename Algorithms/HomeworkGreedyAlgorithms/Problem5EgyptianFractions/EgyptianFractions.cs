namespace Problem5EgyptianFractions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EgyptianFractions
    {
        public static void Main()
        {
            int[] fractionInput = Console.ReadLine().Split('/').Select(int.Parse).ToArray();
           var fraction = new Fraction(fractionInput[0], fractionInput[1]);
            var startFraction = new Fraction(fractionInput[0], fractionInput[1]);

            if (fraction.Numerator == 0 || fraction.Numerator >= fraction.Denominator)
            {
                Console.WriteLine("Error (fraction is equal to or greater than 1)");
                return;
            }

            
            var result = new List<Fraction>();
            for (int i = 2; i < int.MaxValue; i++)
            {
               
                var newFraction = new Fraction(1, i);
                int compare = fraction.CompareTo(newFraction);
                if (compare >= 0)
                {
                    fraction = Fraction.Substract(fraction, newFraction);
                    result.Add(newFraction);
                    if (compare == 0)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine("{0}/{1} = {2}", startFraction.Numerator, startFraction.Denominator, string.Join(" + ", result));
        }

        private class Fraction : IComparable<Fraction>
        {
            public Fraction(long numerator, long denominator)
            {
                this.Numerator = numerator;
                this.Denominator = denominator;
            }

            public long Numerator { get; private set; }

            public long Denominator { get; private set; }

            public int CompareTo(Fraction other)
            {
                long denominator = this.Denominator * other.Denominator;
                long firstNumerator = denominator / this.Denominator * this.Numerator;
                long secondNumerator = denominator / other.Denominator * other.Numerator;

                return firstNumerator.CompareTo(secondNumerator);
            }

            public override string ToString()
            {
                return $"{this.Numerator}/{this.Denominator}";
            }

            public static Fraction Substract(Fraction fraction, Fraction newFraction)
            {
                long denominator = fraction.Denominator*newFraction.Denominator;
                long firstNumerator = denominator/fraction.Denominator*fraction.Numerator;
                long secondNumerator = denominator / newFraction.Denominator * newFraction.Numerator;

                long numerator = firstNumerator - secondNumerator;

                return new Fraction(numerator, denominator);
            }
        }
    }
}
