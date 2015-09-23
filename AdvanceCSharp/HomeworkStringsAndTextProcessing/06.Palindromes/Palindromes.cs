using System;
using System.Collections.Generic;


class Palindromes
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(new char[] {' ', ',', '.', '!', '?'}, StringSplitOptions.RemoveEmptyEntries);

        SortedSet<string> palindromes = new SortedSet<string>();

        foreach (var word in input)
        {
            bool isPalindrom = CheckWordIsPalindrom(word);

            if (isPalindrom)
            {
                palindromes.Add(word);
            }
        }

        Console.WriteLine(string.Join(", ", palindromes));
    }

    private static bool CheckWordIsPalindrom(string word)
    {
        bool isPalindrome = true;
        Queue<char> queue = new Queue<char>();

        for (int i = 0; i < word.Length/2; i++)
        {          
                queue.Enqueue(word[i]);            
        }
       
        for (int i = word.Length - 1; i >= word.Length / 2; i--)
        {            
            if (queue.Count > 0 && queue.Dequeue() != word[i])
            {
                isPalindrome = false;
            }
        }

        return isPalindrome;
    }
}

