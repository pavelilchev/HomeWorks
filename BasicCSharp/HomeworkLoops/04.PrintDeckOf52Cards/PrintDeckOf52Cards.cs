using System;
using System.Text;
class PrintDeckOf52Cards
{
    static void Main()
    {
        string [] cards = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
        char[] notation = { '\u2663', '\u2666', '\u2665', '\u2660' };
        for (int i = 0; i < cards.Length; i++)
        {
            for (int j = 0; j < notation.Length; j++)
            {
                Console.Write(cards[i] + notation[j] + " ");
            }
            Console.WriteLine();
        }
    }
}

