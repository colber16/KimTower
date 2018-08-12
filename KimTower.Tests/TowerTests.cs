
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

        [Test, TestCase(StructureTypes.Office, ExpectedResult = 6)]
        [TestCase(StructureTypes.Condo, ExpectedResult = 2)]
        public int PopulationIncreasesWhenStructureIsAdded(StructureTypes structure)
        {
            var tower = new Tower();
            var builder = new Builder();
            var range = new Range(0, 6);
            builder.BuildRoom(structure, range, 1, false, tower);
            return tower.Population;
        }
    }
}
