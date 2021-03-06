﻿namespace KimTower.Data.Rooms
{
    using System.Collections.Generic;

    public interface IRoom
    {
        List<Person> People { get; set; }

        int Segments { get; }

        Range Range { get; set; }

        bool Occupied { get; set; }

        int Population { get; }

        void SetOccupancy(Tower tower, int floorNumber);
    }
}