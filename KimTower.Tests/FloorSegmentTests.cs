
namespace KimTower.Tests
{
    using System;
    using NUnit.Framework;
    using KimTower.Data;

    public class FloorSegmentTests
    {
        [Test]
        [TestCase(10, 8, 1, ExpectedResult = "Invalid Segments.")]
        public void NegativeSegmentsAreNotValid(int x, int x2, int floorNumber)
        {
            var floor = new Floor(x, x2, floorNumber);
           
        }
    }
}
