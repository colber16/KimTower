namespace KimTower.Data
{
    using System.Collections.Generic;

    public interface IRoom
    {
        List<Person> People { get; set; }

        int Segments { get; }

        Range Range { get; set; }

        bool Occupied { get; set; }

        void SetOccupancy(Tower tower, int floorNumber);
    }
}