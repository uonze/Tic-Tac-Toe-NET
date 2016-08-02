namespace TicTacToe.Domain.Model
{
    using System;
    using System.Drawing;

    public class Board
    {
        private const int size = 3;
        private CellType[,] grid;

        public Board()
        {
            this.grid = new CellType[size, size];
        }

        public int Width
        {
            get { return this.grid.GetLength(1); }
        }

        public int Height
        {
            get { return this.grid.GetLength(0); }
        }

        public CellType GetCellAtPostion(Point position)
        {
            return this.grid[position.X, position.Y];
        }

        public void SetCell(Point position, CellType status)
        {
            if (position.X < 0 || position.X > (this.Width - 1))
            {
                throw new ArgumentOutOfRangeException("X position", "Board set cell X axis out of bounds.");
            }

            if (position.Y < 0 || position.Y > (this.Height - 1))
            {
                throw new ArgumentOutOfRangeException("Y position", "Board set cell Y axis out of bounds.");
            }

            if (this.grid[position.X, position.Y] != CellType.Free)
            {
                throw new ArgumentException("Board cell already occupied.");
            }

            this.grid[position.X, position.Y] = status;
        }

        public int CountCells()
        {
            return (int)Math.Pow(size, 2);
        }

        public int CountFreeCells()
        {
            var count = 0;

            for (int i = 0; i < this.Height; i++)
            {
                for (int j = 0; j < this.Width; j++)
                {
                    if (this.grid[i, j] == CellType.Free)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public int CountOccupiedCells()
        {
            return this.CountCells() - this.CountFreeCells();
        }
    }
}