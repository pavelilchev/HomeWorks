using System;

class CountSubstringOccurrences
{
    static void Main()
    {
        string text = Console.ReadLine();
        string substring = Console.ReadLine();

        int count = 0;
        int index = -1;

        do
        {
            index = text.IndexOf(substring, index + 1, StringComparison.CurrentCultureIgnoreCase);
            if (index >= 0)
            {
                count++;
            }
        }
        while (index >= 0);

            Console.WriteLine(count);
    }
}

