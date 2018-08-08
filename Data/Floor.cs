
namespace KimTower.Data
{
    using System.Collections.Generic;
    using System.Linq;

    public class Floor : BasicFloor
    {


        public Floor(Range range, int floorNumber) : base(range, floorNumber)
        {
            
        }

        public void AddRoom(IRoom room)
        {
            if (IsRangeAvailable(room.Range))
            {
                this.Rooms.Add(room);
            }

        }

        public bool HasLobby() => Rooms.Any(l => l is Lobby);



       
    }
}