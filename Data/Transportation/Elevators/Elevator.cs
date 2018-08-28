
namespace KimTower.Data.Transportation.Elevators
{
    using System;

    public class Elevator : BaseElevator
    {
        static int segments = StructureInfo.elevatorInfo.Segments;

        static int cost = StructureInfo.elevatorInfo.ConstructionCost;

        public Elevator(int x, int floorNumber) : base(segments, cost, x, floorNumber)
        {
        }
    }
}
