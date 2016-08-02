namespace TicTacToe.Domain.Services
{
    using System;
    using TicTacToe.Domain.Model;

    public class PlayerFactory
    {
        public static Player GetPlayer(PlayerType type, string name, CellStatus mark)
        {
            Player player = null;

            switch (type)
            {
                case PlayerType.Human:
                    player = new HumanPlayer(name, mark);
                    break;

                case PlayerType.ComputerEasy:
                    player = new EasyPlayer(name, mark);
                    break;

                case PlayerType.ComputerHard:
                    player = new HardPlayer(name, mark);
                    break;

                default:
                    throw new ArgumentException("Invalid Player Type.");
            }

            return player;
        }
    }
}