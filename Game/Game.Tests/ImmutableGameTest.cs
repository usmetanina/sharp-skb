using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Game.Tests
{
    [TestClass]
    public class ImmutableGameTest : GameTest
    {
        public ImmutableGameTest()
        {
            this.game = new ImmutableGame(1, 2, 3, 4, 5, 6, 7, 8, 0);
        }
       
        [TestMethod]
        public void ImmutableGame_MoveCell_MustReturnUpdateGame()
        {
            ImmutableGame newGame = (ImmutableGame)game.Shift(8);
            Assert.AreEqual(8, game.Field[2, 1]);
            Assert.AreEqual(0, game.Field[2, 2]);

            Assert.AreEqual(0, newGame.Field[2, 1]);
            Assert.AreEqual(8, newGame.Field[2, 2]);
        }
    }
}
