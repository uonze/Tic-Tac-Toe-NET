namespace TicTacToe.Domain.Model
{
    using System;

    public abstract class Player
    {
        public Player(string name, CellType mark)
        {
            this.Name = name;

            if (mark != CellType.Free)
            {
                this.Mark = mark;
            }
            else
            {
                throw new ArgumentException("Invalid marker type.", "mark");
            }
        }

        public CellType Mark { get; }

        public string Name { get; set; }

        public string Score { get; }
    }
}