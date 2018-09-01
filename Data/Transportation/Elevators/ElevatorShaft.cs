
namespace KimTower.Data.Transportation.Elevators
{
    using System;
    using System.Collections.Generic;

    public class ElevatorShaft :ITransportation
    {
        public int FloorNumber { get; set; }
        public Range Range { get; set; }
        public ElevatorCar Car { get; set; }
        public List<WaitingArea> WaitingAreas { get; set; }
       

        public ElevatorShaft(int floorNumber, Range range)
        {
            this.FloorNumber = floorNumber;
            this.Range = new Range(range.StartX, range.EndX);
            this.WaitingAreas = new List<WaitingArea> { new WaitingArea(this.Cars[0].Capacity) };
        }
        //add car
    }
}
