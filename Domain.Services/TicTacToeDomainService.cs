namespace Domain.Services
{
    using System;
    using System.Drawing;
    using TicTacToe.Domain.Model;

    public class TicTacToeDomainService
    {
        private Board board;

        private Player playerOne;
        private Player playerTwo;

        public TicTacToeDomainService(Player playerOne, Player playerTwo)
        {
            this.board = new Board();

            this.playerOne = playerOne;
            this.playerTwo = playerTwo;
        }

        public GameStatus MakePlay(Player player, Point play)
        {
            if (this.GetGameStatus() != GameStatus.OnGoing)
            {
                throw new InvalidOperationException("Cannot make a play because the game has already finished.");
            }

            this.board.SetCell(play, player.Mark);
            return this.GetGameStatus();
        }

        public GameStatus GetGameStatus()
        {
            return this.GetWinner() == null ? GameStatus.OnGoing : GameStatus.Finished;
        }

        public Player GetWinner()
        {
            throw new NotImplementedException();
        }
    }
}