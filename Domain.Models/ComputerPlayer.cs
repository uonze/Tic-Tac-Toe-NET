namespace TicTacToe.Domain.Model
{
    using System;

    public abstract class ComputerPlayer : Player
    {
        public ComputerPlayer(string name, CellStatus mark)
            : base(name, mark)
        {
        }

        public abstract Tuple<int, int> NextMove(CellStatus[,] board);
    }
}