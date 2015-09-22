
using System;
using System.Collections.Generic;

public class ReversedListTest
{

    public static void Main()
    {
        ReversedList<int> testList = new ReversedList<int>();
        //List<int> testList = new List<int>();

        for (int i = 0; i < 20; i++)
        {
            testList.Add(i);
        }


        Console.WriteLine(testList);

        testList.Remove(3);

        Console.WriteLine(testList);
        Console.WriteLine(testList.Count);

        Console.ReadLine();
    }
}

