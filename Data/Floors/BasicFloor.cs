
namespace KimTower.Data.Floors
{
    using System.Collections.Generic;
    using KimTower.Data.Rooms;
    using KimTower.Data.Transportation;
    using KimTower.Data.Transportation.Elevators;

    public abstract class BasicFloor
    {
        public List<IRoom> Rooms { get; set; }

        public Ledger Ledger { get; private set; }

        public List<ITransportation> Transportations { get; set; }

        public Range Range { get; set; }


        protected BasicFloor(Range range)
        {
            this.Rooms = new List<IRoom>();
            this.Ledger = new Ledger(0, 0);
            this.Transportations = new List<ITransportation>();
            this.Range = range;
        }

        public bool IsRangeAvailable(Range newRange)
        {
            if (this.Rooms.Count > 0)
            {
                foreach (var room in this.Rooms)
                {
                    if (newRange.StartX >= room.Range.StartX && newRange.EndX <= room.Range.EndX)
                    {
                        return false;
                    }
                }
            }
            return true;

        }

        public Range GetExtendedFloorRange(Range range)
        {
            int smallestX = this.Range.StartX;
            int largestX2 = this.Range.EndX;

            if (range.StartX <= this.Range.StartX)
            {
                smallestX = range.StartX;

            }

            if (range.EndX >= this.Range.EndX)
            {
                largestX2 = range.EndX;
            }

            return new Range(smallestX, largestX2);

        }

        public void ExtendRange(Range range)
        {
            this.Range = range;
        }

        public int GetSegments()
        {
            return Range.EndX - Range.StartX;
        }

        public int GetSegments(Range range)
        {
            return range.EndX - range.StartX;
        }

        public void AddStairs(int bottomFloor)
        {
            this.Transportations.Add(new StairCase(bottomFloor));

        }

        public void AddElevator(int startingX, int floorNumber)
        {
            this.Transportations.Add(new Elevator(startingX, floorNumber));

        }




    }
}
