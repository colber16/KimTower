using System;
namespace KimTower.Data
{
    public interface IRentable
    {
        int Rent { get; }

        int Cost { get; }

        bool Occupied { get; set; }

    }
}
