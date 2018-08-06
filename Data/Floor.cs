
namespace KimTower.Data
{
    using System.Collections.Generic;
    using System.Linq;

    public class Floor
    {
        public List<IRoom> Rooms { get; set; }

        //public int Segments { get; set; }

        public int FloorNumber { get; set; }

        public Ledger Ledger {get; private set;}

        public List<StairCase> Stairs { get; set; }

        public Position Position { get; private set; }
       
        public bool IsPreexisting { get; set; }

        public Range Range { get; set; }


        public Floor(Range range, int floorNumber)
        {
            //get rid of segments
            //open floor space from rooms position
            this.Rooms = new List<IRoom>();
            //this.Segments = position.X2 - position.X;
            this.FloorNumber = floorNumber; //position.FloorNumber;
            this.Ledger = new Ledger();
            this.Stairs = new List<StairCase>();
            //this.Position = position; 
            this.IsPreexisting = false;
            this.Range = range;
        }

        public void ExtendRange(Range range)
        {
            this.Range = range;
            //ExtendSegments(position.X2 - position.X);
        }

        public bool IsRangeAvailable(Range newRange)
        {      
            foreach (var room in this.Rooms)
            {
                if(newRange.StartX >= room.Range.StartX && newRange.EndX <= room.Range.EndX)
                {
                    return false;
                }
            }
            return true;
        }
        public int GetSegments()
        {
            return Range.EndX - Range.StartX;
        }
        //public void ExtendSegments(int segments)
        //{
        //    this.Segments = segments;
        //}


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
        //does an item n a list know where it is in the list?
        public void AddStairs(int bottomFloor)
        {
            this.Stairs.Add(new StairCase(bottomFloor));

        }

        public void AddRoom(IRoom room)
        {
            if(IsRangeAvailable(room.Range))
            {
                //this.OpenFloorSpace
                this.Rooms.Add(room);
            }

        }
        //public void UpdateOpenSpace()
        //{
            
        //}
        //public bool IsRequestedPositionOpen(Position requestedPosition)
        //{
        //    foreach(var openSpace in this.OpenFloorSpace)
        //    {
        //        if (requestedPosition.X >= openSpace.X)
        //        {
        //            if (requestedPosition.X2 <= openSpace.X2)
        //            {
        //                return false;
        //            }
        //        }
        //    }
           
        //    return true;
        //}
       
    }
}