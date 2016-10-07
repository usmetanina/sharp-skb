using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game.Tests
{
    [TestClass]
    public class GameTest
    {
        protected Game game;

        public GameTest()
        {
            this.game = new Game(1, 2, 3, 4, 5, 6, 7, 8, 0);
        }

        protected virtual Game CreateNewGame(params int[] cells)
        {
            return new Game(cells);
        }
     
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Game_MoveCellAndAdjacentCellIsNotZero_MustThrowException()
        {
            game.Shift(5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Game_TryCreateImpossibleFieldWithIncorrectSizeField_MustThrowException()
        {
            game = CreateNewGame(1, 2, 3, 4, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Game_TryCreateImpossibleFieldWithIncorrectCell_MustThrowException()
        {
            game = CreateNewGame(1, 2, 36, 0);
        }   

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Game_TryCreateImpossibleFieldWithRepeatCell_MustThrowException()
        {
            game = CreateNewGame(1, 2, 2, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Game_TryApplyCellToIndexOverFieldSize_MustThrowException()
        {
            double cell = game[5, 6];
        }

        [TestMethod]
        public void Game_TryApplyCellToIndex_MustReturnCell()
        {
            double cell = game[1, 0];
            Assert.AreEqual(4, cell);
        }
      
    }
}
