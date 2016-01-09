namespace Minesweeper.Messeges
{
    using System;

    public static class Messege
    {
        public const string NextRowCol = "Enter row and collumn: ";

        public const string EndGameMessege = "Made in Bulgaria!";

        public const string WinMessege = "Good job! you found all emthy cells!";

        public const string EnterNameMessege = "Plese, enter your name: ";

        public const string LoseMessege = "You lose! You have {0} points. ";

        public const string WrongCommandMessege = "Unknown command!";

        public const string EmptyRatingMessege = "Empty!";

        public static readonly string GreetingMessege = "Lets play \"Minesweeper\". "
            + Environment.NewLine + "Test your luck and find all mines. "
            + Environment.NewLine + "Commands:"
            + Environment.NewLine + "'top' - show raiting,"
            + Environment.NewLine + "'restart' - start a new game,"
            + Environment.NewLine + "'exit' - close the game.";
    }
}
