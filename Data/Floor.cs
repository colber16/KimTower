
namespace KimTower.Data
{
    using System.Collections.Generic;
    using System.Linq;

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