
namespace KimTower.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using KimTower.Data.Rooms;

    public class Floor : BasicFloor, IFloor
    {

        public Floor(Range range) : base(range)
        {
            
        }

        public void AddRoom(IRoom room)
        {
            if (IsRangeAvailable(room.Range))
            {
                this.Rooms.Add(room);
            }

        }

    }
}