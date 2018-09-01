
namespace KimTower.Data.Transportation.Elevators
{
    using System.Collections.Generic;

    public interface IElevator
    {
        int Segments { get; }

        Range HorizontalRange { get; set; }

        bool Occupied { get; set; }

        int PopulationLevel { get; }

        int Cost { get; }

        int BottomFloor { get; set; }

        int TopFloor { get; set; }

        List<ElevatorCar> Cars { get; }

        List<WaitingArea> WaitingAreas { get; }

        int GetPopulationLevel();

    }
}
