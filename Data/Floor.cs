
namespace KimTower.Data
{
    using System.Collections.Generic;
    using System.Linq;

    public class Floor
    {
        public List<IRoom> Rooms { get; set; }

        public int FloorNumber { get; set; }

        public Ledger Ledger {get; private set;}

        public List<StairCase> Stairs { get; set; }

        public Position Position { get; private set; }
       
        public bool IsPreexisting { get; set; }

        public Range Range { get; set; }


        public Floor(Range range, int floorNumber)
        {
            this.Rooms = new List<IRoom>();
            this.FloorNumber = floorNumber; 
            this.Ledger = new Ledger();
            this.Stairs = new List<StairCase>();
            this.IsPreexisting = false;
            this.Range = range;
        }

        public void ExtendRange(Range range)
        {
            this.Range = range;
        }

        public bool IsRangeAvailable(Range newRange)
        {      
            if(this.Rooms.Count > 0)
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

        public int GetSegments()
        {
            return Range.EndX - Range.StartX;
        }

        public Range GetExtendedFloorRange(Range range)
        {
            int smallestX = this.Range.StartX;
            int largestX2 = this.Range.EndX;

            if (range.StartX <= this.Range.StartX)
            {
                smallestX = range.StartX;

                if (range.EndX >= this.Range.EndX)
                {
                    largestX2 = range.EndX;
                }
            }

            return new Range(smallestX, largestX2);

        }

        public void AddStairs(int bottomFloor)
        {
            this.Stairs.Add(new StairCase(bottomFloor));

        }

        public void AddRoom(IRoom room)
        {
            if(IsRangeAvailable(room.Range))
            {
                this.Rooms.Add(room);
            }

        }
        public bool IsLobbyFloor() => FloorNumber == 1;

        public bool HasLobby() => Rooms.Any(l => l is Lobby);

       
    }
}