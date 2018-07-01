using System;
namespace KimTower
{
    public interface ITransportation
    {
        int Capacity { get; }

        int Population { get; set; }

        bool InUse { get; set; }

        WaitingRoom WaitingRoom { get; set; }


    }
}
