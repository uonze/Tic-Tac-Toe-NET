namespace TicTacToe.Domain.Model
{
    using System;

    public class EasyPlayer : ComputerPlayer
    {
        public EasyPlayer(string name, CellStatus mark)
            : base(name, mark)
        {
        }

        public override Tuple<int, int> NextMove(CellStatus[,] board)
        {
            throw new NotImplementedException();
        }
    }
}