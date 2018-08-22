
namespace KimTower.Tests
{
    using System;
    using NUnit.Framework;
    using KimTower.Data;
    using System.Collections.Generic;
    using KimTower.Data.Floors;

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

        [TestCase(0, 6, ExpectedResult = true)]
        public bool IsFloorRangePreexistingOnParentSecondFloorReturnsTrue(int startX, int endX)
        {
            var builder = new Builder();
            var lobby = new Lobby(1);
            var tower = new Tower();
            var range = new Range(startX, endX);

            tower.AddFloor(lobby);

            builder.BuildStuff(1, range, StructureTypes.Office, false, tower);
            builder.BuildStuff(2, range, StructureTypes.Office, false, tower);

            return FloorValidation.IsRangeExistingOnParent(range, tower.Floors[1].Range);
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
        [Test]
        public void ChargesForAllSegments()
        {
            var tower = new Tower();
            var builder = new Builder();
            var globalProperties = new GlobalProperties();
            //var existingFloor = new Floor(new Range(0, 10));
            //tower.Floors.Add(existingFloor);
            //tower.Floors.Insert(1, existingFloor);

            //builder.BuildFloor(new Range(0, 20), 1, StructureTypes.Floor, true, tower);

            var range = new Range(0, 20);
            var gameLoop = new GameLoop();
            gameLoop.PayForStructure(StructureTypes.Floor, false, 0, range); //just room just floor or Room plus floor

            Assert.That(gameLoop.GlobalProperties.Money, Is.EqualTo(1990000));

        }
    }
}
