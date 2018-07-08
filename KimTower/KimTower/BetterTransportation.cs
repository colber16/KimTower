using System;
namespace KimTower
{
    public interface IBetterTransportation
    {
        Range Range { get; set; }
    }


    public class Elevator : IBetterTransportation
    {
        public Range Range { get; set; }

        public Shaft Shaft { get; set; }

        public Elevator(int position)
        {
            this.Range = GetRange(position, this.Shaft.Car.Segments);
        }

        static Range GetRange(int position, int segments)
        {
           return new Range(position, segments);
        }
    }

    public class ServiceElevator
    {
        public Elevator Elevator { get; set; }

        public ServiceElevator()
        {

        }
    }

    public class ExpressElevator
    {
        public Elevator Elevator { get; set; }
    }
   
    public class Shaft
    {
        public int Capacity { get; } = 8;

        public ICar Car { get; set; }

        public Shaft(ICar car)
        {
            this.Car = car;
        }
    }
    public interface ICar
    {
        int Capacity { get; }
        int Segments { get; }
    }

    public class Car : ICar
    {
        public int Capacity { get; } = 20;
        public int Segments { get; } = 4;
    }
    public class ExpressCar : ICar
    {
        public int Capacity { get; } = 40;
        public int Segments { get; } = 6;
    }
}
