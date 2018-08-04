
namespace KimTower.Tests
{
    using System;
    using NUnit.Framework;
    using KimTower.Data;
    using System.Collections.Generic;

    [TestFixture]
    public class FloorTests
    {
        [Test, TestCaseSource(nameof(Positions))]
        public int FloorSegmentsSetter(Position position)
        {
            var floor = new Floor(position);
            return floor.Segments;
        }

        [Test, TestCaseSource(nameof(PositionsExtended))]
        public int ExtendPositionIncreasesSegments(Position originalposition, Position extendedPosition)
        {
            var floor = new Floor(originalposition);
            floor.ExtendPosition(extendedPosition);
            return floor.Segments;
        }

        [Test, TestCaseSource(nameof(ExtendedReturnPositions))]
        public Position GetExtendedFloorSegmentsReturnsLargerPosition(Position originalposition, Position extendedPosition)
        {
            var floor = new Floor(originalposition);
            return floor.GetExtendedFloorPosition(extendedPosition);

        }
      

        [Test]
        [TestCase("l 1 2", 0, ExpectedResult = 4) ]
        //[TestCase("o 2 0", 1, ExpectedResult = 6)]
        public int ProperFloorSegmentsFromRoomSegments(string input, int floorIndex)
        {

            var gameLoop = new GameLoop();
            var isProcessed = gameLoop.ProcessInput(input);
            return gameLoop.tower.Floors[floorIndex].Segments;
        }

        [TestCase("o 2 0", ExpectedResult = false)]
        public bool RoomInputIsNotProcessedWithoutLobbyBeingBuilt(string input)
        {

            var gameLoop = new GameLoop();
            return gameLoop.ProcessInput(input);

        }

      
        static List<TestCaseData> Positions = new List<TestCaseData> 
        {
            new TestCaseData(new Position(1, 2, 1)).Returns(1), 
            new TestCaseData(new Position(8, 20, 1)).Returns(12)
        };

        static List<TestCaseData> PositionsExtended = new List<TestCaseData>
        {
            
            new TestCaseData(new Position(0, 1, 1), new Position(0, 2, 1)).Returns(2),
            new TestCaseData(new Position(10, 12, 1), new Position(8, 20, 1)).Returns(12),
            new TestCaseData(new Position(10, 12, 1), new Position(8, 12, 1)).Returns(4)
        };
        static List<TestCaseData> ExtendedReturnPositions = new List<TestCaseData>
        {

            new TestCaseData(new Position(0, 1, 1), new Position(0, 2, 1)).Returns(new Position(0, 2, 1)),
            new TestCaseData(new Position(10, 12, 1), new Position(8, 20, 1)).Returns(new Position(8, 20, 1)),
            new TestCaseData(new Position(10, 12, 1), new Position(8, 12, 1)).Returns(new Position(8, 12, 1))
        };
    }
}
