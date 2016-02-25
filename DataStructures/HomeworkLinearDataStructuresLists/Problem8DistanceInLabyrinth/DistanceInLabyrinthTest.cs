namespace Problem8DistanceInLabyrinth
{
    public static class DistanceInLabyrinthTest
    {
        public static void Main()
        {
            var matrix = new[,]
            {
                { "0", "0", "0", "x", "0", "x" },
                { "0", "x", "0", "x", "0", "x" },
                { "0", "*", "x", "0", "x", "0" },
                { "0", "x", "0", "0", "0", "0" },
                { "0", "0", "0", "x", "x", "0" },
                { "0", "0", "0", "x", "0", "x" }
            };

            var labyrinth = new Labyrinth(matrix);
            labyrinth.Print();
        }
    }
}
