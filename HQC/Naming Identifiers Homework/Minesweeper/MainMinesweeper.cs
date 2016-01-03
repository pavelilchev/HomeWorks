namespace Minesweeper
{
    using Engine;
    using Interfaces;
    using IO;

    public class MainMinesweeper
    {
        public static void Main()
        {
            IUserInterface userInterface = new ConsoleUserInterface();

            IEngine engine = new MinesweeperEngine(userInterface);
            engine.Run();
        }
    }
}
