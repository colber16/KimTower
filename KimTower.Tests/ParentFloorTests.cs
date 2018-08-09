
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
            var builder = new Builder();
            var lobby = (StructureTypes)'l';
            var tower = new Tower();

            var floor = builder.BuildFloor(new Range(4, 0), 0, lobby,false, tower);
            var parentFloor = tower.GetParentFloor(floor);
            Assert.IsNull(parentFloor);
        }

        //How to test higher floors.
    }
}
