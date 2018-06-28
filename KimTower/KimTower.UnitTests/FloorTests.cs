using NUnit.Framework;

namespace KimTower.UnitTests
{
    [TestFixture]
    public class FloorTests
    {
        [Test]
        [TestCase(0, 1, 1, 0, false)]
        public void ParentFloorGetter(int startPosition, int parentFloor, int segments, int totalSegments, bool isBelowGround)
        {
            var floor = new Floor(startPosition, parentFloor, segments, totalSegments, isBelowGround);
            Assert.AreEqual(parentFloor, floor.ParentFloor);
        }

        [Test]
        [TestCase(0, 1, 1, 0, false, ExpectedResult = 2)]
        [TestCase(0, 0, 1, 0, false, ExpectedResult = 1)]
        [TestCase(0, 1, 1, 0, true, ExpectedResult = -1)]
        [TestCase(0, -1, 1, 0, true, ExpectedResult = -2)]
        public int FloorGetter(int startPosition, int parentFloor, int segments, int totalSegments, bool isBelowGround)
        {
            var floor = new Floor(startPosition, parentFloor, segments, totalSegments, isBelowGround);
            return floor.FloorNumber;
        }

        [Test]
        [TestCase(1, 1, 1, 0, false, ExpectedResult = 1)]
        [TestCase(0, 0, 12, 2, false, ExpectedResult = 14)]
        [TestCase(2, 1, 1, 3, true, ExpectedResult = 4)]
        [TestCase(0, -1, 1, 4, true, ExpectedResult = 5)]
        public int TotalSegmentGetter(int startPosition, int parentFloor, int segments, int totalSegments, bool isBelowGround)
        {
            var floor = new Floor(startPosition, parentFloor, segments, totalSegments, isBelowGround);
            return floor.TotalSegments;
        }

        [Test]
        [TestCase(1, 1, 1, 0, false, ExpectedResult = 2)]
        [TestCase(0, 0, 12, 2, false, ExpectedResult = 12)]
        [TestCase(2, 1, 1, 3, true, ExpectedResult = 3)]
        [TestCase(0, -1, 1, 4, true, ExpectedResult = 1)]
        public int TotalPositionSetter(int startPosition, int parentFloor, int segments, int totalSegments, bool isBelowGround)
        {
            var floor = new Floor(startPosition, parentFloor, segments, totalSegments, isBelowGround);
            return floor.Position.XSecondCoordinate;
        }

    }
}
