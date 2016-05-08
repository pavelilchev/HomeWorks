namespace Problem4TowerOfHanoi
{
    using System;
    using System.Linq;

    public class TowerOfHanoiTest
    {
        public static void Main()
        {
            int numbersOfDisks = int.Parse(Console.ReadLine());
            var range = Enumerable.Range(1, numbersOfDisks).Reverse();
            var tower = new TowerOfHanoi(range);
            tower.StartMovingDisks();
        }
    }
}
