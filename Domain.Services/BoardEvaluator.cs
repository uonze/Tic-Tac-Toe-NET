namespace TicTacToe.Domain.Services
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using TicTacToe.Domain.Model;

    public class BoardEvaluator
    {
        private Board board;

        public BoardEvaluator(Board board)
        {
            if (board == null)
            {
                throw new ArgumentNullException("board", "Board cannot be null.");
            }

            this.board = board;
        }

        public Nullable<CellType> GetWinner()
        {
            Nullable<CellType> winner = null;

            this.ForEachCell((row, col, mark) =>
            {
                var cellPosition = new Point(row, col);
                var directions = Enum.GetValues(typeof(Direction)).Cast<Direction>();

                foreach (var direction in directions)
                {
                    var vector = this.GetDirectionVector(direction);
                    var inlineCells = this.GetInlineCells(cellPosition, vector);

                    if (this.IsCellInsideBoard(inlineCells.Last()))
                    {
                        foreach (var point in inlineCells)
                        {
                            var cellMark = this.board.GetCellAtPostion(point);
                            if (cellMark != mark)
                            {
                                break;
                            }
                        }
                    }
                }
            });

            return winner;
        }

        private void ForEachCell(Action<int, int, CellType> action)
        {
            for (int row = 0; row < this.board.Height; row++)
            {
                for (int col = 0; col < this.board.Width; col++)
                {
                    action(row, col, this.board.GetCellAtPostion(new Point(row, col)));
                }
            }
        }

        private bool IsCellInsideBoard(Point cell)
        {
            if (cell.X < 0 || cell.X > (this.board.Width - 1))
            {
                return false;
            }

            if (cell.Y < 0 || cell.Y > (this.board.Height - 1))
            {
                return false;
            }

            return true;
        }

        private List<Point> GetInlineCells(Point cell, Point vector)
        {
            var cells = new List<Point>() { cell };

            for (int i = 0; i < 2; i++)
            {
                cells.Add(new Point(cells.Last().X + vector.X, cells.Last().Y + vector.Y));
            }

            return cells;
        }

        private Point GetDirectionVector(Direction direction)
        {
            switch (direction)
            {
                case Direction.North: return new Point(0, 1);
                case Direction.Northeast: return new Point(1, 1);
                case Direction.East: return new Point(1, 0);
                case Direction.Southeast: return new Point(1, -1);
                case Direction.South: return new Point(0, -1);
                case Direction.Southwest: return new Point(-1, -1);
                case Direction.West: return new Point(-1, 0);
                case Direction.Northwest: return new Point(-1, 1);
                default: return new Point(0, 0);
            }
        }
    }
}