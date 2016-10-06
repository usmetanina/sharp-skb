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

            Assert.AreEqual(2,game.GetLocation(8).Y);
            Assert.AreEqual(1, game.GetLocation(0).Y);
            Assert.AreEqual(2, game.GetLocation(8).X);
            Assert.AreEqual(2, game.GetLocation(0).X);
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

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Game_TryApplyCellToIndexOverFieldSize_MustThrowException()
        {
            Game game = new Game(1, 2, 3, 0);
            double cell = game[5, 6];
        }

        [TestMethod]
        public void Game_TryApplyCellToIndex_MustReturnCell()
        {
            Game game = new Game(1, 2, 3, 0);
            double cell = game[1, 0];

            Assert.AreEqual(3, cell);
        }

        [TestMethod]
        public void ImmutableGame_MoveCell_MustReturnUpdateGame()
        {
            ImmutableGame game = new ImmutableGame(1, 2, 3, 0);
            ImmutableGame newGame = game.Shift(3);

            Assert.AreEqual(3, game.Field[1,0]);
            Assert.AreEqual(0, game.Field[1, 1]);

            Assert.AreEqual(0, newGame.Field[1, 0]);
            Assert.AreEqual(3, newGame.Field[1, 1]);
        }


        [TestMethod]
        public void DecoratorGame_MoveCells_MustReturnStartGameAndAllSteps()
        {
            ImmutableGameDecorator game = new ImmutableGameDecorator(1, 2, 3, 0);
            ImmutableGameDecorator newGame;
            newGame=game.Shift(3);
            newGame=game.Shift(1);

            Assert.AreEqual(0, newGame[0, 0]);
            Assert.AreEqual(2, newGame.GetSteps().Count);
            Assert.AreEqual(1, newGame.GetStartGame().Field[0, 0]);
        }
      
    }
}
