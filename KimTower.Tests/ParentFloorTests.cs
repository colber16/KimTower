
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
            //var lobby = new Lobby(1 , 1);
            var gameLoop = new GameLoop();
            var lobby = (StructureTypes)'l';
            var tower = new Tower();

            gameLoop.BuildStructure(lobby, 1, 1, new string[] { "0000" });
            var parentFloor = tower.GetParentFloor(1);
            Assert.IsNull(parentFloor);
        }
    }
}
