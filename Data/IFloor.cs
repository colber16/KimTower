
namespace KimTower.Data
{
    using System.Collections.Generic;

    public interface IFloor
    {
        List<IRoom> Rooms { get; set; }

        Ledger Ledger { get; }

        List<StairCase> Stairs { get; set; }

        Range Range { get; set; }

        void AddStairs(int bottomFloor);
        Range GetExtendedFloorRange(Range range);
        void ExtendRange(Range range);
        int GetSegments();
    }
}
