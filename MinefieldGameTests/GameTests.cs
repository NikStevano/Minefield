using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinefieldGame;

namespace MinefieldGameTests
{
    [TestClass()]
    public class GameTests
    {

        [TestMethod()]
        public void EdgeMovementSuccessTest()
        {
            Game game = new Game(8, 14, 62);

            // we will try to move too many times, hit 13 mines along the way

            // move right
            for (int i = 0; i < 18; i++)
            {
                game.ProcessCommand('r');
            }
            // then move up
            for (int i = 0; i < 18; i++)
            {
                game.ProcessCommand('u');
            }

            GameState result = game.GetGameState();

            Assert.IsTrue(result.gameOver);
            Assert.AreEqual(result.moves, 14);
            Assert.AreEqual(result.lives, 1);
        }

        [TestMethod()]
        public void DiagonalMovementSuccessTest()
        {
            Game game = new Game(8, 14, 62);
            for (int i = 0; i < 8; i++)
            {
                // move up
                game.ProcessCommand('u');
                // then move right
                game.ProcessCommand('r');
            }

            GameState result = game.GetGameState();

            Assert.IsTrue(result.gameOver);
            Assert.AreEqual(result.moves, 14);
            Assert.AreEqual(result.lives, 1);
        }

        [TestMethod()]
        public void NoMinesSuccessTest()
        {
            Game game = new Game(8, 1, 0);
            // no mines and only one life
            // go diagonal
            for (int i = 0; i < 8; i++)
            {
                // move up
                game.ProcessCommand('u');
                // then move right
                game.ProcessCommand('r');
            }

            GameState result = game.GetGameState();

            Assert.IsTrue(result.gameOver);
            Assert.AreEqual(result.moves, 14);
            Assert.AreEqual(result.lives, 1);
        }

        [TestMethod()]
        public void OutOfLivesTest()
        {
            Game game = new Game(8, 1, 62);
            // move up, it will hit a mine
            game.ProcessCommand('u');

            GameState result = game.GetGameState();

            Assert.IsTrue(result.gameOver);
            Assert.AreEqual(result.moves, 1);
            Assert.AreEqual(result.lives, 0);
        }

        [TestMethod()]
        public void ArgumentExceptionTest()
        {
            try
            {
                // too many mines
                Game game = new Game(8, 1, 100);
                Assert.Fail("No exception thrown!");
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentException));
            }
        }

    }
}
