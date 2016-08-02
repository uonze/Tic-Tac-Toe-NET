namespace TicTacToe.Domain.Model
{
    using System;

    public class HumanPlayer : Player
    {
        public HumanPlayer(string name, CellStatus mark)
            : base(name, mark)
        {
        }
    }
}