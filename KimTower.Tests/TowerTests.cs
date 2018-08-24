
namespace KimTower.Tests
{
    using System;
    using NUnit.Framework;
    using KimTower.Data;
    using KimTower.Data.Floors;

    [TestFixture]
    public class TowerTests
    {
        [Test, TestCase("l 2 3", ExpectedResult = false)]

        public bool FloorAddInAscendingOrder(string input)
        {
            var tower = new Tower();
            var gameLoop = new GameLoop();

            return gameLoop.ProcessInput(input);
        }

        [Test, TestCase(StructureTypes.Office, ExpectedResult = 6)]
        [TestCase(StructureTypes.Condo, ExpectedResult = 2)]
        public int PopulationIncreasesWhenRoomIsAdded(StructureTypes structure)
        {
            var tower = new Tower();
            var builder = new Builder();
            var range = new Range(0, 6);
            builder.BuildRoom(structure, range, 1, false, tower);
            return tower.Population;
        }

        [Test, TestCase(StructureTypes.Office, ExpectedResult = 1000)]
        public int CollectRentAddsOfficeRentToProfit(StructureTypes structure)
        {
            var tower = new Tower();
            var builder =new Builder();
            var range = new Range(0, 6);
            var time = new Time(0, 0, Day.WeekdayTwo, 0, 0);

            tower.AddFloor(new Lobby(0));
            tower.Floors[0].ExtendRange(new Range(0, 12));
            tower.AddFloor(new Floor(range));

            builder.BuildRoom(structure, range, 1, true, tower);
            builder.BuildStairs(0, tower);

            tower.CollectRent(time);

            return tower.Floors[1].Ledger.TotalProfit;
        }
        [Test, TestCase(StructureTypes.Condo, ExpectedResult = 0)]
        public int CollectRentForCondoDoesNotAddToProfit(StructureTypes structure)
        {
            var tower = new Tower();
            var builder = new Builder();
            var range = new Range(0, 6);
            var time = new Time(0, 0, Day.WeekdayTwo, 0, 0);

            tower.AddFloor(new Lobby(0));
            tower.Floors[0].ExtendRange(new Range(0, 12));
            tower.AddFloor(new Floor(range));

            builder.BuildRoom(structure, range, 1, true, tower);
            builder.BuildStairs(0, tower);

            tower.CollectRent(time);

            return tower.Floors[1].Ledger.TotalProfit;
        }
    }
}
