namespace TicTacToe.Domain.Model
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    public class Board
    {
        private const int Size = 3;
        private CellStatus[,] grid;

        public Board()
        {
            this.grid = new CellStatus[Size, Size];
        }

        public Board(CellStatus[,] grid)
        {
            this.grid = grid;
        }

        public int Width
        {
            get { return this.grid.GetLength(1); }
        }

        public int Height
        {
            get { return this.grid.GetLength(0); }
        }

        public static List<Point> GetInlineCells(Point cellPosition, Point vector)
        {
            var cells = new List<Point>() { cellPosition };

            for (int i = 1; i < Size; i++)
            {
                var newPoint = new Point(cells.Last().X, cells.Last().Y);
                newPoint.Offset(vector);

                if (IsCellInBounds(newPoint))
                {
                    cells.Add(newPoint);
                }
                else
                {
                    return new List<Point>();
                }
            }

            return cells;
        }

        public static bool AreCellsInBounds(List<Point> cellPositions)
        {
            foreach (var cell in cellPositions)
            {
                if (!IsCellInBounds(cell))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsCellInBounds(Point cellPosition)
        {
            if (cellPosition.X < 0 || cellPosition.X > (Size - 1))
            {
                return false;
            }

            if (cellPosition.Y < 0 || cellPosition.Y > (Size - 1))
            {
                return false;
            }

            return true;
        }

        public CellStatus GetCellStatusAtPostion(Point position)
        {
            return this.grid[position.Y, position.X];
        }

        public void SetCell(Point position, CellStatus status)
        {
            if (!IsCellInBounds(position))
            {
                throw new ArgumentOutOfRangeException("Position", "Board set cell position out of bounds.");
            }

            if (this.grid[position.Y, position.X] != CellStatus.Free)
            {
                throw new ArgumentException("Board cell already occupied.");
            }

            this.grid[position.Y, position.X] = status;
        }

        public int CountCells()
        {
            return (int)Math.Pow(Size, 2);
        }

        public int CountFreeCells()
        {
            var count = 0;

            for (int i = 0; i < this.Height; i++)
            {
                for (int j = 0; j < this.Width; j++)
                {
                    if (this.grid[i, j] == CellStatus.Free)
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

        public bool CheckIfInlineCellsHaveTheSameMark(List<Point> inlineCells, CellStatus markToTestAgainst)
        {
            return inlineCells.Count == Size && inlineCells.Select(cell => this.GetCellStatusAtPostion(cell)).All(cell => cell == markToTestAgainst);
        }
    }
}