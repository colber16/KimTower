
namespace KimTower.Tests
{
    using System;
    using NUnit.Framework;
    using KimTower.Data;

    [TestFixture]
    public class TowerTests
    {
        [Test, TestCase("l 2 3", ExpectedResult = false)]

        public bool FloorAddInAscendingOrder(string input)
        {
            var tower = new Tower();
            var gameLoop = new GameLoop();

            return gameLoop.ProcessInput(input);
        }
    }
}
