namespace Minesweeper.Engine
{
    using System;
    using Interfaces;

    public class Player : IPlayer
    {
        private string name;
        private int points;

        public Player(string name, int points)
        {
            this.name = name;
            this.points = points;
        }

        public Player()
        {
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this.name = value;
            }
        }

        public int Points
        {
            get
            {
                return this.points;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Points cannot be negative!");
                }

                this.points = value;
            }
        }
    }
}
