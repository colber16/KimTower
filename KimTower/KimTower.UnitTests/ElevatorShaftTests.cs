//using System;
//using NUnit.Framework;
//using System.Collections.Generic;

//namespace KimTower.UnitTests
//{
//    public class ElevatorShaftTests
//    {
//        [Test, TestCase( 3, ExpectedResult = 4)]
//        public int GetSegments(int x)
//        {
//            var floor = new Floor(new Range(1, 10), 10, 14, false);
//            floor.AddElevatorShaft(1);
//            return floor.ElevatorShaft.Segments;
//        }

//        [Test, TestCase(2, ExpectedResult = 1)]
//        public int GetElevatorCarCount(int x)
//        {
//            var floor = new Floor(new Range(1, 10), 10, 14, false);
//            floor.AddElevatorShaft(1);
//            return floor.ElevatorShaft.ElevatorCars.Count;
//        }

//        [Test, TestCase(3, ExpectedResult = 7)]
//        public int GetRange(int x)
//        {
//            var floor = new Floor(new Range(1, 10), 10, 14, false);
//            floor.AddElevatorShaft(x);
//            return floor.ElevatorShaft.Range.XSecondCoordinate;
//        }

//        //[Test, TestCase(3, 10, 14, false, ExpectedResult = 18)]
      
//        //public int ExtendFloorSpanUp(int numberOfFloors, int segments, int parentFloor, bool isBelowGround)
//        //{
//        //    var floor = new Floor(new Range(1, 10), segments, parentFloor, isBelowGround);
//        //    floor.AddElevatorShaft(1);
//        //    floor.ElevatorShaft.FloorSpan = floor.ElevatorShaft.ExtendFloorSpan(numberOfFloors);
//        //    return floor.ElevatorShaft.FloorSpan.TopFloor;

//        //}
//        //[Test, TestCase(-3, 10, 14, false, ExpectedResult = new Range(12, 15))]
//        //public int ExtendFloorSpanDown(int numberOfFloors, int segments, int parentFloor, bool isBelowGround)
//        //{
//        //    var floor = new Floor(new Range(1, 10), segments, parentFloor, isBelowGround);
//        //    floor.AddElevatorShaft(1);
//        //    floor.ElevatorShaft.FloorSpan = floor.ElevatorShaft.ExtendFloorSpan(numberOfFloors);
//        //    return floor.ElevatorShaft.FloorSpan.BottomFloor;

//        //}
//        [Test, TestCaseSource(nameof(ListSources))]
//        public FloorSpan ExtendFloorSpan(Floor floor, int numberOfFloors)
//        {
//            floor.AddElevatorShaft(1);
//            floor.ElevatorShaft.FloorSpan = floor.ElevatorShaft.ExtendFloorSpan(numberOfFloors);
//            return floor.ElevatorShaft.FloorSpan;

//        }
//        static List<TestCaseData> ListSources = new List<TestCaseData>
//        {
//             new TestCaseData(new Floor(new Range(1, 9), 8, 14, false), 3).Returns(new FloorSpan(15, 18)),
//             new TestCaseData(new Floor(new Range(1, 9), 8, 1, false), -3).Returns(new FloorSpan(-1, 2))

//        };

//    }

//}
