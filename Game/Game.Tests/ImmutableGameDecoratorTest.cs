using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game.Tests
{
    [TestClass]
    public class ImmutableGameDecoratorTest
    {

        [TestMethod]
            public void DecoratorGame_MoveCells_MustReturnStartGameAndAllSteps()
            {
                ImmutableGame game = new ImmutableGame(1, 2, 3, 0);
                ImmutableGameDecorator newGame = new ImmutableGameDecorator(game);

                newGame = newGame.Shift(3);
                newGame = newGame.Shift(1);

                Assert.AreEqual(0, newGame[0, 0]);
                Assert.AreEqual(2, newGame.GetSteps().Count);
                Assert.AreEqual(1, newGame.GetStartGame().Field[0, 0]);
            }
    }
}
