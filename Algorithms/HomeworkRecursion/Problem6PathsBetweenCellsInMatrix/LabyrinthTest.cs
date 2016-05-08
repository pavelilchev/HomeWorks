namespace Problem6PathsBetweenCellsInMatrix
{
   public class LabyrinthTest
    {
        public static void Main()
        {
            char[,] field = {
                {'s', ' ', ' ', ' ', ' ', ' '},
                {' ', '*', '*', ' ', '*', ' '},
                {' ', '*', '*', ' ', '*', ' '},
                {' ', '*', 'e', ' ', ' ', ' '},
                {' ', ' ', ' ', '*', ' ', ' '}};

            //char[,] field = {
            //    {'s', ' ', ' ', ' '},
            //    {' ', '*', '*', ' '},
            //    {' ', '*', '*', ' '},
            //    {' ', '*', 'e', ' '},
            //    {' ', ' ', ' ', ' '}};

            var labyrinth = new Labyrinth(field);
            labyrinth.PrintPaths();
        }
    }
}
