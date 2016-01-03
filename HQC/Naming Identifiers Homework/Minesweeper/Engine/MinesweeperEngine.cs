namespace Minesweeper.Engine
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Messeges;

    public class MinesweeperEngine : IEngine
    {
        private const int BoardCells = 35;
        private const int BoardRows = 5;
        private const int BoardCols = 10;

        private readonly List<IPlayer> topPlayers;
        private readonly IUserInterface userInterface;
        private char[,] board;
        private char[,] bombs;
        private int counter;
        private int row;
        private int col;
        private bool isWinining;
        private bool isDead;

        public MinesweeperEngine(IUserInterface userInterface)
        {
            this.row = 0;
            this.col = 0;
            this.isWinining = false;
            this.userInterface = userInterface;
            this.topPlayers = new List<IPlayer>();
            this.InitializeBoard();
        }

        public void Run()
        {
            this.userInterface.WriteLine(Messege.GreetingMessege);
            this.PrintBoard();

            string command;
            do
            {
                this.userInterface.Write(Messege.NextRowCol);
                command = this.userInterface.ReadLine().Trim();

                command = this.ExecuteCommand(command);

                if (this.isDead)
                {
                    this.ProcessDead();

                    this.InitializeBoard();
                }

                if (this.isWinining)
                {
                    this.ProcessWin();
                    this.InitializeBoard();
                }
            }
            while (command != "exit");

            this.userInterface.WriteLine(Messege.EndGameMessege);
            this.userInterface.ReadLine();
        }

        private void InitializeBoard()
        {
            this.CreateBoard();
            this.PlainBombs();
            this.counter = 0;
            this.isDead = false;
        }

        private void ProcessWin()
        {
            this.userInterface.WriteLine(Messege.WinMessege);
            this.PrintBoard();
            this.userInterface.WriteLine(Messege.EnterNameMessege);
            string name = this.userInterface.ReadLine();
            IPlayer player = new Player(name, this.counter);
            this.topPlayers.Add(player);
            this.PrintTopPlayers();
        }

        private void ProcessDead()
        {
            this.PrintBoard();
            this.userInterface.Write(Messege.LoseMessege + Messege.EnterNameMessege, this.counter);
            string niknejm = this.userInterface.ReadLine();
            Player t = new Player(niknejm, this.counter);
            if (this.topPlayers.Count < 5)
            {
                this.topPlayers.Add(t);
            }
            else
            {
                for (int i = 0; i < this.topPlayers.Count; i++)
                {
                    if (this.topPlayers[i].Points < t.Points)
                    {
                        this.topPlayers.Insert(i, t);
                        this.topPlayers.RemoveAt(this.topPlayers.Count - 1);
                        break;
                    }
                }
            }

            this.topPlayers.Sort((r1, r2) => string.Compare(r2.Name, r1.Name, StringComparison.Ordinal));
            this.topPlayers.Sort((r1, r2) => r2.Points.CompareTo(r1.Points));
            this.PrintTopPlayers();
        }

        private string ExecuteCommand(string command)
        {
            if (command.Length >= 3)
            {
                if (int.TryParse(command[0].ToString(), out this.row) && int.TryParse(command[2].ToString(), out this.col)
                    && this.row <= this.board.GetLength(0) && this.col <= this.board.GetLength(1))
                {
                    command = "turn";
                }
            }

            switch (command)
            {
                case "top":
                    this.PrintTopPlayers();
                    break;
                case "restart":
                    this.InitializeBoard();
                    break;
                case "exit":
                    break;
                case "turn":
                    this.ProcessTurn();
                    break;
                default:
                    this.userInterface.WriteLine(Messege.WrongCommandMessege);
                    break;
            }

            return command;
        }

        private void ProcessTurn()
        {
            if (this.bombs[this.row, this.col] != '*')
            {
                if (this.bombs[this.row, this.col] == '-')
                {
                    this.ProcessPlayerTurn();
                    this.counter++;
                }

                if (BoardCells == this.counter)
                {
                    this.isWinining = true;
                }
                else
                {
                    this.PrintBoard();
                }
            }
            else
            {
                this.isDead = true;
            }
        }

        private void PrintTopPlayers()
        {
            this.userInterface.WriteLine("Points: ");
            if (this.topPlayers.Count > 0)
            {
                for (int i = 0; i < this.topPlayers.Count; i++)
                {
                    this.userInterface.WriteLine("{0}. {1} --> {2} kutii", i + 1, this.topPlayers[i].Name, this.topPlayers[i].Points);
                }

                this.userInterface.WriteLine();
            }
            else
            {
                this.userInterface.WriteLine(Messege.EmptyRatingMessege);
            }
        }

        private void ProcessPlayerTurn()
        {
            char bombsCount = this.CalculateNearBombsCount();
            this.bombs[this.row, this.col] = bombsCount;
            this.board[this.row, this.col] = bombsCount;
        }

        private void PrintBoard()
        {
            int rows = this.board.GetLength(0);
            int cols = this.board.GetLength(1);

            this.userInterface.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            this.userInterface.WriteLine("   ---------------------");
            for (int i = 0; i < rows; i++)
            {
                this.userInterface.Write("{0} | ", i);
                for (int j = 0; j < cols; j++)
                {
                    this.userInterface.Write($"{this.board[i, j]} ");
                }

                this.userInterface.Write("|");
                this.userInterface.WriteLine();
            }

            this.userInterface.WriteLine("   ---------------------\n");
        }

        private void CreateBoard()
        {
            this.board = new char[BoardRows, BoardCols];

            for (int i = 0; i < BoardRows; i++)
            {
                for (int j = 0; j < BoardCols; j++)
                {
                    this.board[i, j] = '?';
                }
            }
        }

        private void PlainBombs()
        {
            this.bombs = new char[BoardRows, BoardCols];

            for (int i = 0; i < BoardRows; i++)
            {
                for (int j = 0; j < BoardCols; j++)
                {
                    this.bombs[i, j] = '-';
                }
            }

            List<int> numbers = new List<int>();
            while (numbers.Count < 15)
            {
                Random random = new Random();
                int number = random.Next(50);
                if (!numbers.Contains(number))
                {
                    numbers.Add(number);
                }
            }

            foreach (int num in numbers)
            {
                int collumn = num / BoardCols;
                int rrow = num % BoardCols;
                if (rrow == 0 && num != 0)
                {
                    collumn--;
                    rrow = BoardCols;
                }
                else
                {
                    rrow++;
                }

                this.bombs[collumn, rrow - 1] = '*';
            }
        }

        private char CalculateNearBombsCount()
        {
            int count = 0;
            int rows = this.board.GetLength(0);
            int cols = this.board.GetLength(1);

            if (this.row - 1 >= 0)
            {
                if (this.bombs[this.row - 1, this.col] == '*')
                {
                    count++;
                }
            }

            if (this.row + 1 < rows)
            {
                if (this.bombs[this.row + 1, this.col] == '*')
                {
                    count++;
                }
            }

            if (this.col - 1 >= 0)
            {
                if (this.bombs[this.row, this.col - 1] == '*')
                {
                    count++;
                }
            }

            if (this.col + 1 < cols)
            {
                if (this.bombs[this.row, this.col + 1] == '*')
                {
                    count++;
                }
            }

            if ((this.row - 1 >= 0) && (this.col - 1 >= 0))
            {
                if (this.bombs[this.row - 1, this.col - 1] == '*')
                {
                    count++;
                }
            }

            if ((this.row - 1 >= 0) && (this.col + 1 < cols))
            {
                if (this.bombs[this.row - 1, this.col + 1] == '*')
                {
                    count++;
                }
            }

            if ((this.row + 1 < rows) && (this.col - 1 >= 0))
            {
                if (this.bombs[this.row + 1, this.col - 1] == '*')
                {
                    count++;
                }
            }

            if ((this.row + 1 < rows) && (this.col + 1 < cols))
            {
                if (this.bombs[this.row + 1, this.col + 1] == '*')
                {
                    count++;
                }
            }

            return char.Parse(count.ToString());
        }
    }
}