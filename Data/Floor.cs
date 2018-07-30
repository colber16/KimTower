
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

        public Floor(int x, int x2, int floorNumber)
        {
            this.Rooms = new List<IRoom>();
            this.Segments = x2 - x;
            this.FloorNumber = floorNumber;
            this.Ledger = new Ledger();
            this.Stairs = new List<StairCase>();
            this.Position = new Position(x, x2, floorNumber);
        }
        public void ExtendPosition(Position position)
        {
            this.Position = position;
        }
        public void ExtendSegments(int segments)
        {
            this.Segments += segments;
        }
        //hmmmm.....
        public void IsOccupied(Office room, Tower tower)
        {
            if(tower.HasFirstFloorAccess(this.FloorNumber))
            {
                room.Occupied = true;
            }
            // or floor with that extends to 1

        }
       
    }
}