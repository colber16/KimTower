
namespace KimTower.Data.Floors
{
    using System.Collections.Generic;
    using KimTower.Data.Rooms;
    using KimTower.Data.Transportation;

    public class Floor : BasicFloor, IFloor
    {
        
        public int Population { get; set; }

        public Floor(Range range) : base(range)
        {
           
        }

        public void AddRoom(IRoom room)
        {
            if (IsRangeAvailable(room.Range))
            {
                this.Rooms.Add(room);
            }
            this.Population += room.Population;

        }

    }
}