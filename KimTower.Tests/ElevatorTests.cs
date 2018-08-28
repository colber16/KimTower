namespace KimTower.Tests
{
    using System;
    using NUnit.Framework;
    using KimTower.Data.Transportation.Elevators;

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


    }
}
