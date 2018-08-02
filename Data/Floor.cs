
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
       
        public bool Preexisting { get; set; }

        public Floor(Position position)
        {
            this.Rooms = new List<IRoom>();
            this.Segments = position.X2 - position.X;
            this.FloorNumber = position.FloorNumber;
            this.Ledger = new Ledger();
            this.Stairs = new List<StairCase>();
            this.Position = position; //new Position(position.X, position.X2, position.FloorNumber);
            this.Preexisting = false;
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
        //hmmmm.....
        public void IsOccupied(Office room, Tower tower)
        {
            if(tower.HasFirstFloorAccess(this.FloorNumber))
            {
                room.Occupied = true;
            }
            // or floor with that extends to 1

        }
        //needs to handle all inputs
        public Position GetNewFloorPosition(int x, int x2)
        {

            if (x < this.Position.X)
            {

                if (x2 > this.Position.X2)
                {
                    return new Position(x, x2, this.FloorNumber);
                }
                return new Position(x, this.Position.X2, this.FloorNumber);

            }
            else
            {
                return new Position(x, x2, this.FloorNumber);
            }
        }
       
    }
}