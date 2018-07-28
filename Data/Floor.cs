
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

        public Floor(int segments, int floorNumber)
        {
            this.Rooms = new List<IRoom>();
            this.Segments = segments;
            this.FloorNumber = floorNumber;
            this.Ledger = new Ledger();
            this.Stairs = new List<StairCase>();
        }

        public void ExtendSegments(int segments)
        {
            this.Segments += segments;
        }
        //hmmmm.....
        public void IsOccupied(Office room)
        {
            //foreach(var room in this.Rooms)
            //{
                //if(room is IRentable)
               // {
                    //don't know about other floors
           foreach(var stair in this.Stairs)
            {
                
            }
                    if(this.Stairs.Any(s => s.TopFloor == this.FloorNumber))
                    {
                        room.Occupied = true;
                    }
                  
                //}
           // }
          
             //extends to either 1 or floor with that extends to 1
          


        }

    }
}