using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;


class GenericArraySort
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;


        int[] arrInt = { 4, 6, 9, 8, 1 };
        string[] arrString = { "az", "ti", "toi", "nie" };
        DateTime[] arrDate = { new DateTime(1980, 02, 1), new DateTime(1980, 03, 01), new DateTime(2015, 09, 17) };

        Sort(arrInt);     
        Console.WriteLine(string.Join(", ", arrInt));

        Sort(arrString);
        Console.WriteLine(string.Join(", ", arrString));

        Sort(arrDate);
        Console.WriteLine(string.Join(", ", arrDate));
    }

    //using Selection Sort
    private static void Sort<T>(T[] arr)
    {
        int iterations = arr.Length;
        T minElement = default(T);
        T temp = default(T);
        int index = 0;

        for (int j = 0; j < iterations - 1; j++)
        {
            minElement = arr[j];
            bool haveChange = false;

            for (int i = j + 1; i < iterations; i++)
            {
                var result = Comparer<T>.Default.Compare(arr[i], minElement);
                if (result < 0)
                {
                    minElement = arr[i];
                    index = i;
                    haveChange = true;
                }
            }

            if (haveChange)
            {
                temp = arr[index];
                arr[index] = arr[j];
                arr[j] = temp;
            }
        }
    }
}

