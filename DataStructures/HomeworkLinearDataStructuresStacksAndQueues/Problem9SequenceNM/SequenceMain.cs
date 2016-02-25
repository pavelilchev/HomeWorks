namespace Problem9SequenceNM
{
    using System;
    using System.Linq;

    public static class SequenceMain
    {
        public static void Main()
        {
            string readLine = Console.ReadLine();
            if (readLine != null)
            {
                var startEnd = readLine.Split().Select(int.Parse).ToArray();

                var seq = new Sequence(startEnd[0], startEnd[1]);
                seq.FindSequence();
            }
        }
    }
}
