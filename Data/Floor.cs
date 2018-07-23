
namespace KimTower
{
    using System.Collections.Generic;

    public class Floor
    {
        public List<IRoom> Rooms { get; set; }

        public Floor()
        {
            this.Rooms = new List<IRoom>();
        }
    }
}