using System;
using System.Collections.Generic;
using System.Linq;

namespace KimTower
{

    public interface IElevator
    {
        Range Range { get; set; }

        bool InUse { get; set; }
       
        Elevator Elevator { get; set; }
    }

    public class Elevator 
    {
        public Shaft Shaft { get; set; }

        public FloorSpan FloorSpan { get; }

        public List<WaitingRoom> WaitingRooms { get; set; }

        public int Population { get; }

        public Elevator(ICar car, int floorNumber)
        {
            this.Shaft = new Shaft(car);
            this.FloorSpan = new FloorSpan(floorNumber, floorNumber);
            this.WaitingRooms = new List<WaitingRoom>();
            this.Population = GetPopulation();
        }

        public int GetPopulation()
        {
            var sum = 0;

            foreach(var car in this.Shaft.Cars)
            {
                sum =+ car.Population;
            }
            return sum;
        }
    }

    public static class ElevatorExtentions
    {
        
        public static Range GetRange(this Elevator elevator, int position)
        {
            return new Range(position, elevator.Shaft.Cars.FirstOrDefault().Segments);
        }

        public static FloorSpan ExtendFloorSpan(this Elevator elevator, int numberOfFloors)
        {
            if (numberOfFloors < 0)
            {
                return new FloorSpan(elevator.FloorSpan.BottomFloor + numberOfFloors , elevator.FloorSpan.TopFloor);
            }
            return new FloorSpan(elevator.FloorSpan.BottomFloor, elevator.FloorSpan.TopFloor + numberOfFloors);
        
        }
    }
    public class PassengerElevator : IElevator
    {
        
        public Range Range { get; set; }

        public Elevator Elevator { get; set; }

        public bool InUse { get; set; }
       

        public PassengerElevator(int position, int floorNumber)
        {
            
            this.Elevator = new Elevator(new Car(), floorNumber);
            
            this.Range = this.Elevator.GetRange(position);
           
        }
    }
    //public class ServiceElevator : IElevator
    //{
    //    public Range Range { get; set; }

    //    public Elevator Elevator { get; set; }

    //    public ServiceElevator(int position)
    //    {
    //        this.Elevator = new Elevator(position, new Car());
    //    }
    //}

    //public class ExpressElevator :IElevator
    //{
    //    public Range Range { get; set; }

    //    public Elevator Elevator { get; set; }

    //    public ExpressElevator(int position)
    //    {
    //        this.Elevator = new Elevator(position, new ExpressCar());
    //    }
    //}
   
    public class Shaft
    {
        public int Capacity { get; } = 8;

        public List<ICar> Cars { get; set; }

        public Shaft(ICar car)
        {
            this.Cars = new List<ICar>{ car };

        }


    }
    public interface ICar
    {
        int Capacity { get; }
        int Segments { get; }
        int Population { get; set; }
    }

    public class Car : ICar
    {
        public int Capacity { get; } = 20;

        public int Segments { get; } = 4;

        public int Population { get; set; }

    }
    public class ExpressCar : ICar
    {
        public int Capacity { get; } = 40;

        public int Segments { get; } = 6;

        public int Population { get; set; }

       
    }
}
