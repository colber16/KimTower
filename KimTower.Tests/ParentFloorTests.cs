
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

            var floor = gameLoop.ProcessFloor(0, 4, 0, lobby);
            var parentFloor = tower.GetParentFloor(floor);
            Assert.IsNull(parentFloor);
        }

        //How to test higher floors.
    }
}
