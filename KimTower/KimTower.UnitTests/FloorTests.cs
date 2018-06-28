using System.Collections.Generic;
using NUnit.Framework;

namespace KimTower.UnitTests
{
    [TestFixture]
    public class FloorTests
    {
        //I want to tie this to lobby at some point.
      
        //[TestCase(typeof(Range)range, 1, 1, false, ExpectedResult = 1)]
        [Test, TestCaseSource(nameof(Sources))]
        public int ParentFloorGetter(Range range, int parentFloor, int segments, bool isBelowGround)
        {
            var floor = new Floor(range, parentFloor, segments, isBelowGround);
            return floor.ParentFloor;
        }

        //[Test]
        //[TestCase(0, 1, 1, false, ExpectedResult = 2)]
        //[TestCase(0, 0, 1, false, ExpectedResult = 1)]
        //[TestCase(0, 1, 1, true, ExpectedResult = -1)]
        //[TestCase(0, -1, 1, true, ExpectedResult = -2)]
        //public int FloorNumberGetter(Range range, int parentFloor, int segments, bool isBelowGround)
        //{
        //    var floor = new Floor(range, parentFloor, segments, isBelowGround);
        //    return floor.FloorNumber;
        //}

        //[Test]
        //[TestCase(0, 1, 1, false, ExpectedResult = 1)]
        //[TestCase(8, 0, 3, false, ExpectedResult = 3)]
        //[TestCase(8, 0, 0, false, ExpectedResult = 1)]
        //public int SegmentSetter(Range range, int parentFloor, int segments, bool isBelowGround)
        //{
        //    var floor = new Floor(range, parentFloor, segments, isBelowGround);
        //    return floor.Segments;
        //}

        static IEnumerable<TestCaseData> Sources()
        {
            yield return new TestCaseData(new Range(2, 8), 1, 1, false).Returns(1);
        }



    }
}