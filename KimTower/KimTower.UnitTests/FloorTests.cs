using NUnit.Framework;

namespace KimTower.UnitTests
{
    [TestFixture]
    public class FloorTests
    {
        [Test]
        [TestCase(0, 1, 1, false)]
        public void ParentFloorGetter(int startPosition, int parentFloor, int segments, int totalSegments, bool isBelowGround)
        {
            var floor = new ConstructFloor(startPosition, parentFloor, segments, isBelowGround);
            Assert.AreEqual(parentFloor, floor.ParentFloor);
        }

        [Test]
        [TestCase(0, 1, 1,false, ExpectedResult = 2)]
        [TestCase(0, 0, 1, false, ExpectedResult = 1)]
        [TestCase(0, 1, 1, true, ExpectedResult = -1)]
        [TestCase(0, -1, 1, true, ExpectedResult = -2)]
        public int FloorGetter(int startPosition, int parentFloor, int segments, int totalSegments, bool isBelowGround)
        {
            var floor = new ConstructFloor(startPosition, parentFloor, segments, isBelowGround);
            return floor.FloorNumber;
        }

        //[Test]
        //[TestCase(1, 1, 1, false, ExpectedResult = 1)]
        //[TestCase(0, 0, 12, false, ExpectedResult = 14)]
        //[TestCase(2, 1, 1, true, ExpectedResult = 4)]
        //[TestCase(0, -1, 1, true, ExpectedResult = 5)]
        //public int TotalSegmentGetter(int startPosition, int parentFloor, int segments, int totalSegments, bool isBelowGround)
        //{
        //    var floor = new ConstructFloor(startPosition, parentFloor, segments, isBelowGround);
        //    return floor.TotalSegments;
        //}

        [Test]
        [TestCase(1, 1, 1, false, ExpectedResult = 2)]
        [TestCase(0, 0, 12, false, ExpectedResult = 12)]
        [TestCase(2, 1, 1, true, ExpectedResult = 3)]
        [TestCase(0, -1, 1, true, ExpectedResult = 1)]
        public int TotalPositionSetter(int startPosition, int parentFloor, int segments, bool isBelowGround)
        {
            var floor = new ConstructFloor(startPosition, parentFloor, segments, isBelowGround);
            return floor.Range.XSecondCoordinate;
        }

    }
}
