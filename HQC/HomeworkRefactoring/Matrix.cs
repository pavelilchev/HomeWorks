namespace RotatingWalkinInMatrix
{
    public class Matrix
    {
        private const int PossibleDirections = 8;
        private readonly int dimension;
        private readonly int[,] matrix;
        private int row;
        private int col;
        private int direction;

        public Matrix(int dimension)
        {
            this.row = 0;
            this.col = 0;
            this.direction = 0;
            this.dimension = dimension;
            this.matrix = new int[this.dimension, this.dimension];
        }

        public int[,] GenerateMatrix()
        {
            int value = 1;

            while (true)
            {
                this.matrix[this.row, this.col] = value;

                if (this.CheckIfMatrixFull())
                {
                    break;
                }

                bool haveNeighbor = this.SetNextPosition();

                if (!haveNeighbor)
                {
                    this.FindFirstEmtyCell();
                }

                value++;
            }

            return this.matrix;
        }

        private bool SetNextPosition()
        {
            bool havePossibleNeighbor = false;

            for (int currentDirection = this.direction; currentDirection < PossibleDirections + this.direction; currentDirection++)
            {
                havePossibleNeighbor = !this.CheckOutOfBoundaries(currentDirection);
                if (havePossibleNeighbor)
                {
                    this.direction = currentDirection % PossibleDirections;
                    break;
                }
            }

            return havePossibleNeighbor;
        }

        private bool CheckOutOfBoundaries(int currentDirection)
        {
            int nextRow = 0;
            int nextCol = 0;
            currentDirection %= PossibleDirections;
            switch (currentDirection)
            {
                case 0:
                    nextRow = this.row + 1;
                    nextCol = this.col + 1;
                    break;
                case 1:
                    nextRow = this.row + 1;
                    nextCol = this.col;
                    break;
                case 2:
                    nextRow = this.row + 1;
                    nextCol = this.col - 1;
                    break;
                case 3:
                    nextRow = this.row;
                    nextCol = this.col - 1;
                    break;
                case 4:
                    nextRow = this.row - 1;
                    nextCol = this.col - 1;
                    break;
                case 5:
                    nextRow = this.row - 1;
                    nextCol = this.col;
                    break;
                case 6:
                    nextRow = this.row - 1;
                    nextCol = this.col + 1;
                    break;
                case 7:
                    nextRow = this.row;
                    nextCol = this.col + 1;
                    break;
            }

            if (!(nextRow >= this.dimension || nextRow < 0 || nextCol >= this.dimension || nextCol < 0))
            {
                if (this.matrix[nextRow, nextCol] == 0)
                {
                    this.row = nextRow;
                    this.col = nextCol;
                    return false;
                }
            }

            return true;
        }
        
        private bool CheckIfMatrixFull()
        {
            bool isFill = true;

            for (int i = 0; i < this.dimension; i++)
            {
                for (int j = 0; j < this.dimension; j++)
                {
                    if (this.matrix[i, j] == 0)
                    {
                        isFill = false;
                        break;
                    }
                }

                if (!isFill)
                {
                    break;
                }
            }

            return isFill;
        }

        private void FindFirstEmtyCell()
        {
            for (int r = 0; r < this.dimension; r++)
            {
                for (int c = 0; c < this.dimension; c++)
                {
                    if (this.matrix[r, c] == 0)
                    {
                        this.row = r;
                        this.col = c;
                        this.direction = 0;
                        return;
                    }
                }
            }
        }
    }
}