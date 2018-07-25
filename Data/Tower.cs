
namespace KimTower.Data
{
    using System;
    using System.Collections.Generic;

    public class Tower
    {
        public List<Floor> Floors { get; set; }

        public Tower()
        {
            this.Floors = new List<Floor>();
        }

        public void AddLobby()
        {
            this.Floors.Add(new Floor(4));
            this.Floors[0].Rooms.Add(new Lobby(4));
        }
    }
}
