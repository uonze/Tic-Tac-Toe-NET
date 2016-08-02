namespace TicTacToe.Domain.Model
{
    using System;

    public class HumanPlayer : Player
    {
        public HumanPlayer(string name, CellType mark)
            : base(name, mark)
        {
        }
    }
}