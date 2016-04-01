namespace Problem1ProductsInPriceRange
{
    using System;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class ProductsInPriceRange
    {
        public static void Main()
        {
            var productByPrice = new OrderedMultiDictionary<double, string>(true);
            int linesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < linesCount; i++)
            {
                string input = Console.ReadLine();
                string[] inputArgs = input.Split();
                double price = double.Parse(inputArgs[1]);
                string product = inputArgs[0];

                productByPrice.Add(price, product);
            }

            double[] range = Console.ReadLine().Split().Select(double.Parse).ToArray();

            var productsInRange = productByPrice.Range(range[0], true, range[1], true);

            int count = 0;
            foreach (var product in productsInRange)
            {
                if (count == 20)
                {
                    break;
                }

                Console.WriteLine(product.Key + " " + product.Value.First());
                count++;
            }
        }
    }
}
