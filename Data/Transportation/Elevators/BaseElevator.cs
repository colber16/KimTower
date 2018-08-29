namespace KimTower.Data.Transportation.Elevators
{
    using System;
    using System.Collections.Generic;

    public abstract class BaseElevator : IElevator, ITransportation
    {

        public int Segments { get; }

        public int Cost { get; }

        public Range Range { get; set; }

        public bool Occupied { get; set; }

        public int PopulationLevel { get; private set; }

        public int BottomFloor { get; set; }

        public int TopFloor { get; set; }

        public List<ElevatorCar> Cars { get; set; }

        public List<WaitingArea> WaitingAreas { get; set; }

        protected BaseElevator(int segments, int cost, int startingX, int floorNumber)
        {
            this.Segments = segments;
            this.Range = new Range(startingX, startingX + segments);
            this.BottomFloor = floorNumber;
            this.TopFloor = floorNumber;
            this.Cars = new List<ElevatorCar> {new ElevatorCar(floorNumber)};
            this.Cost = cost + this.Cars[0].Cost;
            this.WaitingAreas = new List<WaitingArea> {new WaitingArea(this.Cars[0].Capacity)};
        }
        public int GetPopulationLevel()
        {
            throw new NotImplementedException();
        }
    }
}
