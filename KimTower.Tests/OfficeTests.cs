
namespace KimTower.Tests
{
    using NUnit.Framework;
    using KimTower.Data;

    [TestFixture]
    public class OfficeTests
    {
       [Test, TestCase(0, 2)]
        public void OfficePosition(int x, int floorNumber)
        {
            var office = new Office(x, floorNumber);
            Assert.That(office.Position, Is.EqualTo(new Position(x, x + office.Segments, floorNumber)));
        }

        [Test, TestCase(0, 2)]
        public void OfficeOccupancyIsTrueWhenFirstFloorAccessIsTrue(int x, int floorNumber)
        {
            var tower = new Tower();
            var firstFloor = new Floor(new Position(0, 5, 1));
            var secondFloor = new Floor(new Position(0, 5, 2));
            tower.Floors.Add(firstFloor);
            tower.Floors.Add(secondFloor);
            tower.Floors[0].AddStairs(1);
            tower.Floors[1].AddStairs(1);
            var office = new Office(x, floorNumber);

            office.SetOccupancy(tower);

            Assert.That(office.Occupied, Is.EqualTo(true));

        }

    }
}
