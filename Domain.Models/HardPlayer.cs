namespace TicTacToe.Domain.Model
{
    using System;

    public class HardPlayer : ComputerPlayer
    {
        public HardPlayer(string name, CellType mark)
            : base(name, mark)
        {
        }

        public override Tuple<int, int> NextMove(CellType[,] board)
        {
            throw new NotImplementedException();
        }
    }
}