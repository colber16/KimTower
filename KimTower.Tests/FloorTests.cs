
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
        public int FloorSegmentsSetter(Range range)
        {
            var floor = new Floor(range);
            return floor.GetSegments();
        }

        [Test, TestCaseSource(nameof(RangesExtended))]
        public int ExtendPositionIncreasesSegments(Range r1, Range r2)
        {
            var floor = new Floor(r1);
            floor.ExtendRange(r2);
            return floor.GetSegments();
        }

        [Test, TestCaseSource(nameof(ExtendedReturnRanges))]
        public Range GetExtendedFloorSegmentsReturnsLargerPosition(Range r1, Range r2)
        {
            var floor = new Floor(r1);
            return floor.GetExtendedFloorRange(r2);

        }


        [Test]
        [TestCase("l 0 2", 0, ExpectedResult = 4)]
        //[TestCase("o 2 0", 1, ExpectedResult = 6)]
        public int ProperFloorSegmentsFromRoomSegments(string input, int floorIndex)
        {
            var gameLoop = new GameLoop();
            var isProcessed = gameLoop.ProcessInput(input);
            return gameLoop.tower.Floors[floorIndex].GetSegments();

        }

        [TestCase("o 2 0", ExpectedResult = false)]
        public bool RoomInputIsNotProcessedWithoutLobbyBeingBuilt(string input)
        {
            var gameLoop = new GameLoop();
            return gameLoop.ProcessInput(input);

        }

        [TestCase(3, 7, ExpectedResult = false)]
        public bool IsFloorRangePreesixtingReturnsFalse(int startX, int endX)
        {
            var lobby = new Lobby(1);

            return FloorValidation.IsFloorRangePreexisting(new Range(startX, endX), lobby);
        }

        [TestCase(1, 4, ExpectedResult = true)]
        public bool IsFloorRangePreesixtingReturnsTrue(int startX, int endX)
        {
            var lobby = new Lobby(1);

            return FloorValidation.IsFloorRangePreexisting(new Range(startX, endX), lobby);
        }
        [TestCase(1, 4, ExpectedResult = true)]
        public bool IsFloorRangePreexistingOnParentFloorReturnsTrue(int startX, int endX)
        {
            var lobby = new Lobby(1);
            var tower = new Tower();
            tower.AddFloor(lobby);


            return FloorValidation.IsFloorRangePreexisting(new Range(startX, endX), lobby);
        }
        [TestCase(3, 7, ExpectedResult = false)]
        public bool IsFloorRangePreexistingOnParentFloorReturnsFalse(int startX, int endX)
        {
            var lobby = new Lobby(1);
            var tower = new Tower();
            tower.AddFloor(lobby);


            return FloorValidation.IsFloorRangePreexisting(new Range(startX, endX), lobby);
        }

        static List<TestCaseData> Ranges = new List<TestCaseData> 
        {
            new TestCaseData(new Range(1, 2)).Returns(1), 
            new TestCaseData(new Range(8, 20)).Returns(12)
        };

        static List<TestCaseData> RangesExtended = new List<TestCaseData>
        {
            
            new TestCaseData(new Range(0, 1), new Range(0, 2)).Returns(2),
            new TestCaseData(new Range(10, 12), new Range(8, 20)).Returns(12),
            new TestCaseData(new Range(10, 12), new Range(8, 12)).Returns(4)
        };
        static List<TestCaseData> ExtendedReturnRanges = new List<TestCaseData>
        {

            new TestCaseData(new Range(0, 1), new Range(0, 2)).Returns(new Range(0, 2)),
            new TestCaseData(new Range(10, 12), new Range(8, 20)).Returns(new Range(8, 20)),
            new TestCaseData(new Range(10, 12),  new Range(8, 12)).Returns(new Range(8, 12))
        };
    }
}
