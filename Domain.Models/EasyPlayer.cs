namespace TicTacToe.Domain.Model
{
    using System;

    public class EasyPlayer : ComputerPlayer
    {
        public EasyPlayer(string name, CellType mark)
            : base(name, mark)
        {
        }

        public override Tuple<int, int> NextMove(CellType[,] board)
        {
            throw new NotImplementedException();
        }
    }
}