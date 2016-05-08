namespace Problem4TowerOfHanoi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TowerOfHanoi
    {
        private readonly Stack<int> source;
        private readonly Stack<int> destination;
        private readonly Stack<int> spare;
        private int stepsTaken;

        public TowerOfHanoi(IEnumerable<int> source)
        {
            this.source = new Stack<int>(source);
            this.destination = new Stack<int>();
            this.spare = new Stack<int>();
            this.stepsTaken = 0;
        }

        public void StartMovingDisks()
        {
            this.PrintRods();
            this.MoveDisks(this.source.Count, this.source, this.destination, this.spare);
        }

        private void MoveDisks(int bottomDisk, Stack<int> sourceRod, Stack<int> destinationRod, Stack<int> spareRod)
        {
            if (bottomDisk == 1)
            {
                this.stepsTaken++;
                destinationRod.Push(sourceRod.Pop());
                Console.WriteLine($"Step #{this.stepsTaken}: Moved disk {bottomDisk}");
                this.PrintRods();
            }
            else
            {
                this.MoveDisks(bottomDisk - 1, sourceRod, spareRod, destinationRod);
                destinationRod.Push(sourceRod.Pop());
                this.stepsTaken++;
                Console.WriteLine($"Step #{this.stepsTaken}: Moved disk {bottomDisk}");
                this.PrintRods();
                this.MoveDisks(bottomDisk - 1, spareRod, destinationRod, sourceRod);
            }
        }

        private void PrintRods()
        {
            Console.WriteLine("Source: {0}", string.Join(", ", this.source.Reverse()));
            Console.WriteLine("Destination: {0}", string.Join(", ", this.destination.Reverse()));
            Console.WriteLine("Spare: {0}", string.Join(", ", this.spare.Reverse()));
            Console.WriteLine();
        }

    }
}
