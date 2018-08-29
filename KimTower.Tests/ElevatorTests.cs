namespace KimTower.Tests
{
    using System;
    using NUnit.Framework;
    using KimTower.Data.Transportation.Elevators;
    using KimTower.Data;
    using KimTower.Data.Floors;

    [TestFixture]
    public class ElevatorTests
    {
        [Test]
        public void NewElevatorCreatesWaitingArea()
        {
            var elevator = GetElevator(0,0);
            Assert.NotNull(elevator.WaitingAreas);
        }
        public Elevator GetElevator(int x, int floorNumber) => new Elevator(x, floorNumber);
        public Builder GetBuilder() => new Builder();
        public Floor GetFloor() => new Floor(new Range (0, 20));

        [Test]
        public void BuildingElevatorAddsElevatorToFloor()
        {
            var builder = GetBuilder();
            var floor = GetFloor();
            builder.BuildElevator(0, 0, floor);
            Assert.That(floor.Transportations.Count, Is.EqualTo(1));
        }
    }
}
