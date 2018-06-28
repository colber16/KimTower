using NUnit.Framework;

namespace KimTower.UnitTests
{
    [TestFixture]
    public class FloorTests
    {
       



    }
    [TestFixture]
    public class ConstructFloorTests
    {
        //I want to tie this to lobby at some point.
        [Test]
        [TestCase(0, 1, 1, false, ExpectedResult = 1)]
        public int ParentFloorGetter(int startPosition, int parentFloor, int segments, bool isBelowGround)
        {
            var floor = new ConstructFloor(startPosition, parentFloor, segments, isBelowGround);
            return floor.ParentFloor;
        }

        [Test]
        [TestCase(0, 1, 1, false, ExpectedResult = 2)]
        [TestCase(0, 0, 1, false, ExpectedResult = 1)]
        [TestCase(0, 1, 1, true, ExpectedResult = -1)]
        [TestCase(0, -1, 1, true, ExpectedResult = -2)]
        public int FloorNumberGetter(int startPosition, int parentFloor, int segments, bool isBelowGround)
        {
            var floor = new ConstructFloor(startPosition, parentFloor, segments, isBelowGround);
            return floor.FloorNumber;
        }

        [Test]
        [TestCase(0, 1, 1, false, ExpectedResult = 1)]
        [TestCase(8, 0, 3, false, ExpectedResult = 3)]
        [TestCase(8, 0, 0, false, ExpectedResult = 1)]
        public int SegmentSetter(int startPosition, int parentFloor, int segments, bool isBelowGround)
        {
            var floor = new ConstructFloor(startPosition, parentFloor, segments, isBelowGround);
            return floor.Segments;
        }

        [Test]
        [TestCase(1, 1, 1, false, ExpectedResult = 2)]
        [TestCase(0, 0, 12, false, ExpectedResult = 12)]
        [TestCase(2, 1, 1, true, ExpectedResult = 3)]
        [TestCase(0, -1, 1, true, ExpectedResult = 1)]
        public int RangeSetter(int startPosition, int parentFloor, int segments, bool isBelowGround)
        {
            var floor = new ConstructFloor(startPosition, parentFloor, segments, isBelowGround);
            return floor.Range.XSecondCoordinate;
        }

        [Test]
        [TestCase(0, 1, 1, false, ExpectedResult = -500)]
        [TestCase(8, 0, 3, false, ExpectedResult = -1500)]
        [TestCase(8, 0, 0, false, ExpectedResult = -500)]
        public int CostGetter(int startPosition, int parentFloor, int segments, bool isBelowGround)
        {
            var floor = new ConstructFloor(startPosition, parentFloor, segments, isBelowGround);
            return floor.Cost;
        }
    }
}