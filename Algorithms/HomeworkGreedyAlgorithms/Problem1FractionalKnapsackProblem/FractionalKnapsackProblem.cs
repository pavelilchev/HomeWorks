namespace Problem1FractionalKnapsackProblem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FractionalKnapsackProblem
    {
        public static void Main()
        {
            decimal capacity = Console.ReadLine().Split().Skip(1).Select(decimal.Parse).First();
            int itemsCount = Console.ReadLine().Split().Skip(1).Select(int.Parse).First();

            var sortedItems = new SortedSet<Item>();
            for (int i = 0; i < itemsCount; i++)
            {
                var itemsArgs =
                    Console.ReadLine().Split(new[] {' ', '-', '>'}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var item = new Item(decimal.Parse(itemsArgs[0]), decimal.Parse(itemsArgs[1]));
                sortedItems.Add(item);
            }

            decimal totalPrice = 0;
            var result = new Dictionary<decimal, List<Item>>();
            while (capacity > 0)
            {
                var currentItem = sortedItems.Max;
                sortedItems.Remove(currentItem);
                if (capacity - currentItem.Weight >= 0)
                {
                    if (!result.ContainsKey(100))
                    {
                        result.Add(100, new List<Item>());
                    }

                    totalPrice += currentItem.Price;
                    result[100].Add(currentItem);
                }
                else
                {
                    var percentage = capacity/currentItem.Weight*100;
                    if (!result.ContainsKey(percentage))
                    {
                        result.Add(percentage, new List<Item>());
                    }

                    totalPrice += currentItem.Price*percentage/100;
                    result[percentage].Add(currentItem);
                }

                capacity -= currentItem.Weight;
            }

            foreach (var pair in result)
            {
                foreach (var item in pair.Value)
                {
                    Console.WriteLine("Take {0:0.00}% of item with price {1:0.00} and weight {2:0.00}", pair.Key, item.Price, item.Weight);
                }
            }

            Console.WriteLine("Total price: {0:F2}", totalPrice);
        }

        private class Item : IComparable<Item>
        {
            public Item(decimal price, decimal weight)
            {
                this.Price = price;
                this.Weight = weight;
            }

            public decimal Price { get; private set; }

            public decimal Weight { get; private set; }

            public int CompareTo(Item other)
            {
                decimal currentRatio = this.Price/this.Weight;
                decimal otherRatio = other.Price/other.Weight;

                return currentRatio.CompareTo(otherRatio);
            }
        }
    }
}
