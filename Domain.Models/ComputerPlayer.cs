namespace TicTacToe.Domain.Model
{
    using System;

    public abstract class ComputerPlayer : Player
    {
        public ComputerPlayer(string name, CellType mark)
            : base(name, mark)
        {
        }

        public abstract Tuple<int, int> NextMove(CellType[,] board);
    }
}