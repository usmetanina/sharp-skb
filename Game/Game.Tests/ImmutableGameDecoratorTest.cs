using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game.Tests
{
    [TestClass]
    public class ImmutableGameDecoratorTest:GameTest
    {
        public ImmutableGameDecoratorTest()
        {
            ImmutableGame testGame = new ImmutableGame(1, 2, 3, 4, 5, 6, 7, 8, 0);
            game = new ImmutableGameDecorator(testGame);
        }

        protected override Game CreateNewGame(params int[] cells)
        {
            ImmutableGame testGame = new ImmutableGame(cells);
            return new ImmutableGameDecorator(testGame);
        }

        [TestMethod]
        public void DecoratorGame_MoveCells_MustReturnStartGameAndAllSteps()
        {
            ImmutableGame testGame = new ImmutableGame(1, 2, 3, 0);
            ImmutableGameDecorator game = new ImmutableGameDecorator(testGame);

            game = game.Shift(3);
            game = game.Shift(1);

            Assert.AreEqual(0, game[0, 0]);
            Assert.AreEqual(2, (game).GetSteps().Count);
            Assert.AreEqual(1, game.GetStartGame().Field[0, 0]);
        }
    }
}
