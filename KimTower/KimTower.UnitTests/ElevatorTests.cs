using System;
using NUnit.Framework;

namespace KimTower.UnitTests
{
    public class ElevatorTests
    {
        [Test, TestCase(15, 3, ExpectedResult = 4)]
        public int GetSegments(int segments, int x)
        {
            var floor = new Floor(new Range(1, 10), 10, 14, false);
            floor.AddElevator(1);
            var elevatorShaft = new ElevatorShaft(floor, x);
            return elevatorShaft.Segments;
        }
    }
}
