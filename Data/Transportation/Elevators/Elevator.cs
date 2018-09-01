
namespace KimTower.Data.Transportation.Elevators
{
    using System;

    public class Elevator : BaseElevator
    {
        static int segments = StructureInfo.elevatorInfo.Segments;

        static int cost = StructureInfo.elevatorInfo.ConstructionCost;

        public Elevator(int startingX, int floorNumber) : base(segments, cost, startingX, floorNumber)
        {
        }

    }
}
