using System;
namespace KimTower
{
    public class Floor
    {
        public Floor()
        {
        }

        public Position Position { get; set; }

        public int ParentFloor { get; set; }

        public int FloorNumber { get; set; } //negative below ground

        public bool IsLobby { get; set; }

        public int MaintenanceCost { get; set; }

    }
}
