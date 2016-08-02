namespace Domain.Services.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using TicTacToe.Domain.Model;
    using TicTacToe.Domain.Services;

    [TestClass]
    public class BoardEvaluatorTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_BoardNull_ThrowArgumentException()
        {
            // Act
            var target = new BoardEvaluator(null);
        }

        [TestMethod]
        public void GetWinner_BoardEmpty_NoWinner()
        {
            // Arrange
            var board = new Board(new CellStatus[3, 3]
            {
                { CellStatus.Free, CellStatus.Free, CellStatus.Free },
                { CellStatus.Free, CellStatus.Free, CellStatus.Free },
                { CellStatus.Free, CellStatus.Free, CellStatus.Free }
            });

            var target = new BoardEvaluator(board);

            // Act
            var act = target.GetWinner();

            // Assert
            Assert.IsNull(act);
        }

        [TestMethod]
        public void GetWinner_TopRowWithCross_CrossIsWinner()
        {
            // Arrange
            var board = new Board(new CellStatus[3, 3]
            {
                { CellStatus.Circle, CellStatus.Cross, CellStatus.Cross },
                { CellStatus.Free, CellStatus.Free, CellStatus.Free },
                { CellStatus.Free, CellStatus.Free, CellStatus.Free }
            });

            var target = new BoardEvaluator(board);

            // Act
            var act = target.GetWinner();

            // Assert
            Assert.AreEqual(CellStatus.Cross, act);
        }
    }
}