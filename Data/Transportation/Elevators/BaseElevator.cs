namespace KimTower.Data.Transportation.Elevators
{
    using System;
    using System.Collections.Generic;

    public abstract class BaseElevator : IElevator, ITransportation
    {

        public int Segments { get; }

        public int Cost { get; }

        public Range Range { get; set; }



        //public int PopulationLevel { get; private set; }

        public int BottomFloor { get; set; }

        public int TopFloor { get; set; }



        public List<ElevatorShaft> Shafts { get; set; }

        //public List<WaitingArea> WaitingAreas { get; set; }

        protected BaseElevator(int segments, int cost, int startingX, int floorNumber)
        {
            this.Segments = segments;
            this.Range = new Range(startingX, startingX + segments);
            //this.BottomFloor = floorNumber;
            //this.TopFloor = floorNumber;
            //this.Cars = new List<ElevatorCar> {new ElevatorCar(floorNumber)};
            this.Shafts = new List<ElevatorShaft>(floorNumber);
            this.Cost = cost;
            //this.WaitingAreas = new List<WaitingArea> {new WaitingArea(this.Cars[0].Capacity)};
        }
        //Todo Car limit iterate over shaft
        //public int GetPopulationLevel()
        //{
        //    throw new NotImplementedException();
        //}
        //validate floor number before I get here
        //public void SetBottomAndTopFloors(int newBottomFloor, int newTopFloor)
        //{
        //    this.BottomFloor = newBottomFloor;
        //    this.TopFloor = newTopFloor;
        //}
    }
}
