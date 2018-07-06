using System;
using NUnit.Framework;

namespace KimTower.UnitTests
{
    public class ElevatorShaftTests
    {
        [Test, TestCase( 3, ExpectedResult = 4)]
        public int GetSegments(int x)
        {
            var floor = new Floor(new Range(1, 10), 10, 14, false);
            floor.AddElevator(1);
            var elevatorShaft = new ElevatorShaft(floor, x);
            return elevatorShaft.Segments;
        }

        [Test, TestCase(2, ExpectedResult = 1)]
        public int GetElevatorCarCount(int x)
        {
            var floor = new Floor(new Range(1, 10), 10, 14, false);
            floor.AddElevator(1);
            var elevatorShaft = new ElevatorShaft(floor, x);
            return elevatorShaft.ElevatorCars.Count;
        }

        [Test, TestCase(3, ExpectedResult = 7)]
        public int GetRange(int x)
        {
            var floor = new Floor(new Range(1, 10), 10, 14, false);
            floor.AddElevator(1);
            var elevatorShaft = new ElevatorShaft(floor, x);
            return elevatorShaft.Range.XSecondCoordinate;
        }
    }
}
