using System;
using System.Collections.Generic;
using System.Linq;

namespace KimTower
{
    public interface ITransportation
    {
        int Capacity { get; }

        int Population { get; }

        bool InUse { get; set; }

        WaitingRoom WaitingRoom { get; set; }

        int Segments { get; }

        FloorSpan FloorSpan { get; }

        int GetPopulation();
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

    public class ElevatorShaft
    {
        private int capacity = 8;
        private int segments = 4;
        /// <summary>
        /// Elevator car capacity.
        /// </summary>
        /// <value>The capacity.</value>
        public int Capacity => capacity;

        public int Population { get; }

        public bool InUse { get; set; }

        public int Segments => segments;

        public FloorSpan FloorSpan { get; }

        public List<ElevatorCar> ElevatorCars { get; set; }

        public ElevatorShaft(Floor floor)
        {
            this.FloorSpan = new FloorSpan(floor.FloorNumber, floor.FloorNumber);
            this.Population = GetPopulation();
            this.InUse = IsInUse();
            ElevatorCars.Add(AddNewCar());

        }
        //...
        public ElevatorCar AddNewCar()
        {
            return new ElevatorCar();

        }
        public FloorSpan ExtendFloorSpan(int floorNumber)
        {
            if (floorNumber < 0)
            {
                return new FloorSpan(this.FloorSpan.TopFloor, this.FloorSpan.BottomFloor - floorNumber);
            }
            return new FloorSpan(this.FloorSpan.TopFloor + floorNumber, this.FloorSpan.BottomFloor);
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

        public int FloorNumber { get; set; }
        //Range of floors car can travel to, maybe.
        public FloorSpan FloorSpan => throw new NotImplementedException();

        public ElevatorCar()
        {
            this.Population = GetPopulation();
        }
        public int GetPopulation()
        {
            throw new NotImplementedException();
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
    }

    public delegate void IsInUse(WaitingRoom waitingRoom);

}
