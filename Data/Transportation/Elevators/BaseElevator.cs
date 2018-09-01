namespace KimTower.Data.Transportation.Elevators
{
    using System;
    using System.Collections.Generic;

    public abstract class BaseElevator : IElevator, ITransportation
    {

        public int Segments { get; }

        public int Cost { get; }

        public Range HorizontalRange { get; set; }

        public bool Occupied { get; set; }

        public int PopulationLevel { get; private set; }

        public int BottomFloor { get; set; }

        public int TopFloor { get; set; }

        public List<ElevatorCar> Cars { get; set; }

        public List<WaitingArea> WaitingAreas { get; set; }
        public Range Range { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        protected BaseElevator(int segments, int cost, int startingX, int floorNumber)
        {
            this.Segments = segments;
            this.HorizontalRange = new Range(startingX, startingX + segments);
            this.BottomFloor = floorNumber;
            this.TopFloor = floorNumber;
            this.Cars = new List<ElevatorCar> {new ElevatorCar(floorNumber)};
            this.Cost = cost;
            this.WaitingAreas = new List<WaitingArea> {new WaitingArea(this.Cars[0].Capacity)};
        }
        public int GetPopulationLevel()
        {
            throw new NotImplementedException();
        }
        //validate floor number before I get here
        public void SetTopAndBottomFloors(int newTopFloor, int newBottomFloor)
        {
            this.TopFloor = newTopFloor;
            this.BottomFloor = newBottomFloor;
        }
    }
}
