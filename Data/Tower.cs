
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
    }
}
