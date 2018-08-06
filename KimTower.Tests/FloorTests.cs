
namespace KimTower.Tests
{
    using System;
    using NUnit.Framework;
    using KimTower.Data;
    using System.Collections.Generic;

    [TestFixture]
    public class FloorTests
    {
        [Test, TestCaseSource(nameof(Ranges))]
        public int FloorSegments(Range range, int floorNumber)
        {
            var floor = new Floor(range, floorNumber);
            return floor.GetSegments();
        }

        [Test, TestCaseSource(nameof(RangesExtended))]
        public int ExtendRangeIncreasesSegments(Range r1, int floorNumber, Range r2)
        {
            var floor = new Floor(r1, floorNumber);
            floor.ExtendRange(r2);
            return floor.GetSegments();
        }

        [Test, TestCaseSource(nameof(ExtendedReturnRanges))]
        public Range GetExtendedFloorSegmentsReturnsLargerRange(Range r1, int floorNumber, Range r2)
        {
            var floor = new Floor(r1, floorNumber);
            return floor.GetExtendedFloorRange(r2);

        }

        //[Test, TestCaseSource()]
        //public Position FloorIsSetFromRoomPosition(Position position, IRoom room)
        //{
        //    var floor = new Floor(position);

        //}
      
        //needs to use floor number
        [Test]
        [TestCase("l 1 2", 0, ExpectedResult = 4) ]
       // [TestCase("o 2 0", 1, ExpectedResult = 6)]
        public int ProperFloorSegmentsFromRoomSegments(string input, int floorIndex)
        {

            var gameLoop = new GameLoop();
            var isProcessed = gameLoop.ProcessInput(input);
            return gameLoop.tower.Floors[0].GetSegments();
        }

        //[TestCase("o 2 0", ExpectedResult = false)]
        //public bool RoomInputIsNotProcessedWithoutLobbyBeingBuilt(string input)
        //{

        //    var gameLoop = new GameLoop();
        //    return gameLoop.ProcessInput(input);

        //}

      
        static List<TestCaseData> Ranges = new List<TestCaseData> 
        {
            new TestCaseData(new Range(1, 2), 1).Returns(1), 
            new TestCaseData(new Range(8, 20), 1).Returns(12)
        };

        static List<TestCaseData> RangesExtended = new List<TestCaseData>
        {
            
            new TestCaseData(new Range(0, 1), 1, new Range(0, 2)).Returns(2),
            new TestCaseData(new Range(10, 12) ,1, new Range(8, 20)).Returns(12),
            new TestCaseData(new Range(10, 12), 1, new Range(8, 12)).Returns(4)
        };
        static List<TestCaseData> ExtendedReturnRanges = new List<TestCaseData>
        {

            new TestCaseData(new Range(0, 1), 1, new Range(0, 2)).Returns((new Range(0, 2))),
            new TestCaseData(new Range(10, 12), 1, new Range(8, 20)).Returns((new Range(8, 20))),
            new TestCaseData(new Range(10, 12), 1, new Range(8, 12)).Returns((new Range(8, 12)))
        };
    }
}
