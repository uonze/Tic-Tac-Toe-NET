namespace TicTacToe.Domain.Model
{
    using System;

    public abstract class Player
    {
        public Player(string name, CellStatus mark)
        {
            this.Name = name;

            if (mark != CellStatus.Free)
            {
                this.Mark = mark;
            }
            else
            {
                throw new ArgumentException("Invalid marker type.", "mark");
            }
        }

        public CellStatus Mark { get; }

        public string Name { get; set; }

        public string Score { get; }
    }
}