
namespace KimTower.Data
{
    using System.Collections.Generic;
    using System.Linq;

    public class Floor
    {
        public List<IRoom> Rooms { get; set; }

        public int Segments { get; set; }

        public int FloorNumber { get; set; }

        public Ledger Ledger {get; private set;}

        public List<StairCase> Stairs { get; set; }

        public Position Position { get; private set; }
       
        public bool IsPreexisting { get; set; }

        public Floor(Position position)
        {
            this.Rooms = new List<IRoom>();
            this.Segments = position.X2 - position.X;
            this.FloorNumber = position.FloorNumber;
            this.Ledger = new Ledger();
            this.Stairs = new List<StairCase>();
            this.Position = position; 
            this.IsPreexisting = false;
        }

        public void ExtendPosition(Position position)
        {
            this.Position = position;
            ExtendSegments(position.X2 - position.X);
        }

        public void ExtendSegments(int segments)
        {
            this.Segments = segments;
        }

        public Position GetExtendedFloorPosition(Position position)
        {
            int smallestX = this.Position.X;
            int largestX2 = this.Position.X2;

            if (position.X <= this.Position.X)
            {
                smallestX = position.X;

                if (position.X2 >= this.Position.X2)
                {
                    largestX2 = position.X2;
                }
            }

            return new Position(smallestX, largestX2, this.FloorNumber);

        }
        //does an item n a list know where it is in the list?
        public void AddStairs(int floorNumber)
        {
            this.Stairs.Add(new StairCase(floorNumber));

        }
       
    }
}