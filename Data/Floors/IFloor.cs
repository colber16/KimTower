
namespace KimTower.Data.Floors
{
    using System.Collections.Generic;
    using KimTower.Data.Rooms;
    using KimTower.Data.Transportation;

    public interface IFloor
    {
        List<IRoom> Rooms { get; set; }

        Ledger Ledger { get; }

        List<ITransportation> Transportations { get; set; }

        Range Range { get; set; }
       
        int Population { get; set; }

        void AddStairs(int bottomFloor);
        Range GetExtendedFloorRange(Range range);
        void ExtendRange(Range range);
        int GetSegments();
        void AddElevator(int startingX, int floorNumber);
        //int GetUnpaidSegments(Range unpaidRange, StructureTypes structure);
    }
}
