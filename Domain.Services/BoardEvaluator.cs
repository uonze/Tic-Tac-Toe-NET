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

        // Returns null when no winner is found
        public CellStatus? GetWinner()
        {
            CellStatus? winner = null;

            this.ForEachCellNotFree((cellPosition, mark) =>
            {
                var directions = Direction.GetCompassDirections();

                foreach (var direction in directions)
                {
                    var vector = Direction.GetDirectionVector(direction);
                    var inlineCells = Board.GetInlineCells(cellPosition, vector);

                    if (this.board.CheckIfInlineCellsHaveTheSameMark(inlineCells, mark))
                    {
                        winner = mark;
                    }
                }
            });

            if (winner == CellStatus.Free)
            {
                throw new ApplicationException("The winner cannot be a free CellStatus.");
            }

            return winner;
        }

        private void ForEachCellNotFree(Action<Point, CellStatus> action)
        {
            for (int row = 0; row < this.board.Height; row++)
            {
                for (int col = 0; col < this.board.Width; col++)
                {
                    var cellPosition = new Point(col, row);
                    var cellStatus = this.board.GetCellStatusAtPostion(cellPosition);

                    if (cellStatus != CellStatus.Free)
                    {
                        action(cellPosition, cellStatus);
                    }
                }
            }
        }
    }
}