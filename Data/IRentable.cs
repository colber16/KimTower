using System;
namespace KimTower.Data
{
    public interface IRentable
    {
        int Rent { get; }

        bool Occupied { get; set; }

        int PayRent();

    }
}
