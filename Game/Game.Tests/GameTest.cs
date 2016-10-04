using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game.Tests
{
    [TestClass]
    public class GameTest
    {

        [TestMethod]
        public void Game_MoveCellAndAdjacentCellIsZero_MustReturnUpdateField()
        {
            Game game = new Game(1, 2, 3, 4, 5, 6, 7, 8, 0);
            game.Shift(8);

            Assert.AreEqual(2,game.GetLocation(8).y);
            Assert.AreEqual(1, game.GetLocation(0).y);
            Assert.AreEqual(2, game.GetLocation(8).x);
            Assert.AreEqual(2, game.GetLocation(0).x);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Game_MoveCellAndAdjacentCellIsNotZero_MustThrowException()
        {
            Game game = new Game(1, 2, 3, 4, 5, 5, 6, 7, 8, 0);
            game.Shift(5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Game_TryCreateImpossibleFieldWithIncorrectSizeField_MustThrowException()
        {
            Game game = new Game(1, 2, 3, 4, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Game_TryCreateImpossibleFieldWithIncorrectCell_MustThrowException()
        {
            Game game = new Game(1, 2, 36, 0);
        }   

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Game_TryCreateImpossibleFieldWithRepeatCell_MustThrowException()
        {
            Game game = new Game(1, 2, 2, 0);
        }
    }
}
