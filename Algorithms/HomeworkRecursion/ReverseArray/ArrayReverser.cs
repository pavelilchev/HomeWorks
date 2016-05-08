namespace ReverseArray
{
    using System;
    using System.Linq;

    public class ArrayReverser
    {
        public static void Main()
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6 };
           // var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var reversedArr = ReverseArray(arr, 0);
            Console.WriteLine(string.Join(" ", reversedArr));
        }

        private static int[] ReverseArray(int[] arr, int index)
        {
            if (index != arr.Length / 2)
            {
                var swaped = arr[index];
                arr[index] = arr[arr.Length - index - 1];
                arr[arr.Length - index - 1] = swaped;

                ReverseArray(arr, index + 1);
            }

            return arr;
        }
    }
}

