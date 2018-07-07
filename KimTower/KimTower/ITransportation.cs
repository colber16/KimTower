using System;
using System.Collections.Generic;
using System.Linq;

namespace KimTower
{
    public interface ITransportation
    {
        //don't apply to elevator shafts
        //int Capacity { get; }

        int Population { get; }

        bool InUse { get; set; }

       // WaitingRoom WaitingRoom { get; set; }

        int Segments { get; }

        FloorSpan FloorSpan { get; }

        int GetPopulation();

        // Range Range { get; set; }
    }

    public class Stairs : ITransportation
    {
        private int capacity = 10;
        private int segments = 8;

        public int Capacity => capacity;

        public int Population { get; }

        public bool InUse { get; set; }

        public WaitingRoom WaitingRoom { get; set; }

        public int Segments => segments;

        public FloorSpan FloorSpan { get; }

        public Stairs(Floor floor)
        {
            this.Population = GetPopulation();
            this.InUse = IsInUse();
            this.FloorSpan = new FloorSpan(floor.FloorNumber, floor.FloorNumber + 1);
        }
        public bool IsInUse() => this.WaitingRoom.Population > 0;

        public int GetPopulation()
        {

            if (this.WaitingRoom.Population % capacity == 0)
            {
                return capacity;
            }
            else
            {
                return this.WaitingRoom.Population % capacity;
            }
        }

    }
    public class Escalator : Stairs
    {
        public Escalator(Floor floor) : base(floor)
        {
        }
    }

    public class ElevatorShaft : ITransportation
    {
        protected int carCapacity = 8;
        protected int segments = 4;
       
        public int CarCapacity => carCapacity;

        public int Population { get; }

        public bool InUse { get; set; }

        public int Segments => segments;

        public FloorSpan FloorSpan { get; set; }

        public List<ElevatorCar> ElevatorCars { get; set; }

        public Range Range  { get; set; }
        //Xcoor needs to be in floor range
        public ElevatorShaft(Floor floor, int x)
        {
            this.FloorSpan = new FloorSpan(floor.FloorNumber, floor.FloorNumber);
            this.Range = new Range(x, x + segments);
            this.ElevatorCars = new List<ElevatorCar>{new ElevatorCar(floor)};
            this.Population = GetPopulation();
            this.InUse = IsInUse();

        }

        public virtual ElevatorCar AddNewCar(Floor floor)
        {
            if(floor.ElevatorShaft.ElevatorCars.Any(car => car.FloorNumber == floor.FloorNumber))
            {
                throw new NotImplementedException();
            }
            if(!this.FloorSpan.IsFloorInFloorSpan(this, floor.FloorNumber))
            {
                throw new NotImplementedException();
            }
            return new ElevatorCar(floor);

        }

        public FloorSpan ExtendFloorSpan(int numberOfFloors)
        {
            if (numberOfFloors < 0)
            {
                return new FloorSpan(this.FloorSpan.BottomFloor + numberOfFloors , this.FloorSpan.TopFloor);
            }
            return new FloorSpan(this.FloorSpan.BottomFloor, this.FloorSpan.TopFloor + numberOfFloors);
        }

        public int GetPopulation()
        {
            var population = 0;

            foreach (var car in this.ElevatorCars)
            {
                population += car.Population;
            }
            return population;
        }

        public bool IsInUse()
        {
            return this.ElevatorCars.Any(car => car.WaitingRoom.Population > 0);
        }


    }

    public class ServiceElevatorShaft : ElevatorShaft
    {
        public ServiceElevatorShaft(Floor floor, int x) : base(floor, x)
        {
           
        }

        public bool IsServicePerson(Person person)
        {
            throw new NotImplementedException();
        }
    }

    public class ExpressElevatorShaft : ElevatorShaft
    {

        public ExpressElevatorShaft(Floor floor, int x) : base(floor, x)
        {
            this.segments = 6;
        }

        public override ElevatorCar AddNewCar(Floor floor)
        {
            if(floor.FloorNumber % 15 != 0)
            {
                throw new NotImplementedException();
            }
            return new ExpressElevatorCar(floor);
        }

    }

    internal class ExpressElevatorCar : ElevatorCar
    {
        private int capacity = 40;
        private int segments = 6;

        public new int Capacity => capacity;

        public new int Segments => segments;

        public ExpressElevatorCar(Floor floor) : base(floor)
        {
            
        }
    }

    public class ElevatorCar : ITransportation
    {
        private int capacity = 20;
        private int segments = 4;
        /// <summary>
        /// Person capacity.
        /// </summary>
        /// <value>The capacity.</value>
        public int Capacity => capacity;

        public int Population { get; }

        public bool InUse { get; set; }

        public WaitingRoom WaitingRoom { get; set; }

        public int Segments => segments;

        public int FloorNumber { get; private set; }
        //Is there a limit
        public FloorSpan FloorSpan { get;  }


        public ElevatorCar(Floor floor)
        {
            //this.Population = GetPopulation();
            this.WaitingRoom = new WaitingRoom(floor, floor.ElevatorShaft.Range.XCoordinate);
            this.InUse = IsInUse();
            this.FloorNumber = floor.FloorNumber;
            //this.FloorSpan = new FloorSpan(floor.ElevatorShaft.FloorSpan.BottomFloor, floor.ElevatorShaft.FloorSpan.TopFloor);
            //because ElevatorShaft is not finished being created when the above is called
            //So there is a null reference.
            this.FloorSpan = new FloorSpan(floor.FloorNumber, floor.FloorNumber);
        }
        public int GetPopulation()
        {
            if (this.WaitingRoom.Population % capacity == 0)
            {
                return capacity;
            }
            else
            {
                return this.WaitingRoom.Population % capacity;
            }
        }
        public bool IsInUse()
        {
            return this.WaitingRoom.Population > 0;
        }

        public int Move(int desiredFloor)
        {
            //check if floor number in span
            return desiredFloor;
        }
    }

    public struct FloorSpan
    {

        public FloorSpan(int bottomFloor, int topFloor)
        {
            this.BottomFloor = bottomFloor;
            this.TopFloor = topFloor;
        }

        public int BottomFloor { get; set; }

        public int TopFloor { get; set; }
        //Shrinking elevators....
        public bool IsFloorInFloorSpan(ElevatorShaft elevatorShaft, int floorNumber)
        {
            return ((floorNumber >= elevatorShaft.FloorSpan.BottomFloor)
                    && (floorNumber <= elevatorShaft.FloorSpan.TopFloor));
            
        }
    }


}
