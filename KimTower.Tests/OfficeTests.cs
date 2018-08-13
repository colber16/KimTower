
namespace KimTower.Tests
{
    using NUnit.Framework;
    using KimTower.Data;

    [TestFixture]
    public class OfficeTests
    {
        [Test, TestCase(0, 2)]
        [TestCase(0, 99)]
        public void OfficeRange(int x, int floorNumber)
        {
            var office = new Office(x, floorNumber);
            Assert.That(office.Range, Is.EqualTo(new Range(x, x + office.Segments)));
        }

        [Test, TestCase(0, 2)]
        public void OfficeOccupancyIsTrueWhenFirstFloorAccessIsTrue(int x, int floorNumber)
        {
            var tower = new Tower();
            var firstFloor = new Floor(new Range(0, 5));
            var secondFloor = new Floor(new Range(0, 5));
            tower.Floors.Add(firstFloor);
            tower.Floors.Add(secondFloor);
            tower.Floors[0].AddStairs(1);
            tower.Floors[1].AddStairs(1);
            var office = new Office(x, floorNumber);

            office.SetOccupancy(tower, floorNumber);

            Assert.That(office.Occupied, Is.EqualTo(true));

        }
        [Test]
        public void SecondFloorOfficeAdds()
        {
            var tower = new Tower();
            var builder = new Builder();
            var range = new Range(0, 6);

            tower.Floors.Add(new Lobby(0));

            builder.BuildStuff(1, range, StructureTypes.Office, false, tower);
            builder.BuildStuff(2, range, StructureTypes.Office, false, tower);

            Assert.IsNotNull(tower.Floors[2].Rooms[0]);
        }

    }
}
