
namespace KimTower.Tests
{
    using System;
    using NUnit.Framework;
    using KimTower.Data;

    [TestFixture]
    public class ParentFloorTests
    {
        [Test]
        public void ParentFloorOflobbyIsNull()
        {
            var gameLoop = new GameLoop();
            var lobby = (StructureTypes)'l';
            var tower = new Tower();

            gameLoop.BuildStructure(lobby, 1, 1, new string[] { "0000" });
            var parentFloor = tower.GetParentFloor(1);
            Assert.IsNull(parentFloor);
        }

        [Test]
        public void ParentFloorOfSecondFloorOfficeIsOne()
        {
            var gameLoop = new GameLoop();
            var office = (StructureTypes)'o';
            var tower = new Tower();

            tower.AddFloor(new Floor(new Range(1, 9), 1));

            gameLoop.BuildStructure(office, 1, 2, new string[] { "0000" });
            var parentFloor = tower.GetParentFloor(2);
            Assert.AreEqual(1, parentFloor.FloorNumber);
        }

        [Test]
        public void ParentFloorIsNull()
        {
            var gameLoop = new GameLoop();
            var office = (StructureTypes)'o';
            var tower = new Tower();

            tower.AddFloor(new Floor(new Range(1, 9), 1));

            gameLoop.BuildStructure(office, 1, 3, new string[] { "0000" });
            var parentFloor = tower.GetParentFloor(3);
            Assert.IsNull(parentFloor);
        }
    }
}
