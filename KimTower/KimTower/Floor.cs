using System;
using System.Collections.Generic;
namespace KimTower
{
    public interface IFloor
    {

        Range Range { get; set; }

        int ParentFloor { get; }

        int FloorNumber { get; }

        //int MaintenanceCost { get; }

        int Segments { get; set; }


        List<IElevator> Elevators { get; set; }

        List<IRoom> Rooms { get; set; }


        void ExtendFloor(int coordinate);
    }
    //people can be in lobbies
    //public class Lobby : IFloor
    //{
    //    private int parentFloor = 0;

    //    public Range Range { get; set; }

    //    public int ParentFloor => parentFloor;

    //    public int FloorNumber { get; set;}

    //    public int Segments { get; set; }
    //    public List<ITransportation> Transportation { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    //    public void ExtendFloor(int coordinate)
    //    {

    //        if (coordinate < 0)
    //        {
    //            this.Range = new Range(this.Range.XCoordinate + coordinate, this.Range.XCoordinate);

    //        }
    //        else
    //        {
    //            this.Range = new Range(this.Range.XCoordinate, this.Range.XCoordinate + coordinate);
    //        }

    //        this.Segments += Math.Abs(coordinate);
    //    }
    //}
    //floors can not be deleted
    public class Floor : IFloor
    {
        public Range Range { get; set; }

        //public int MaintenanceCost { get { return 0; } }

        public int Segments { get; set; }

        public bool IsBelowGround { get; set; }

        public int ParentFloor { get; set; }

        public int FloorNumber
        {
            get
            {
                if (!IsBelowGround)
                {
                    return this.ParentFloor + 1;
                }
                else
                {
                    if (this.ParentFloor == 1)
                    {
                        return -1;
                    }
                    return this.ParentFloor - 1;
                }
            }
        }

        public List<IElevator> Elevators { get; set; }

        public List<IRoom> Rooms { get; set; }

        public Floor(Range range, int segments, int parentfloor, bool isBelowGround)
        {
            this.ParentFloor = parentfloor;
            this.Range = new Range(range.XCoordinate, range.XSecondCoordinate);
            this.Segments = segments;
            this.IsBelowGround = isBelowGround;
            this.Elevators = new List<IElevator>();
            this.Rooms = new List<IRoom>();
        }
        public Floor()
        {

        }

        public void AddElevator(ElevatorType elevatorType, int xCoordinateRight)
        {
            var factory = new ElevatorFactory();
            var elevator = factory.GetElevator(elevatorType, xCoordinateRight, this.FloorNumber);
            this.Elevators.Add(elevator);
            var waitingRoom = new WaitingRoom(this.Range, elevator);
            this.Rooms.Add(waitingRoom);
            elevator.Elevator.WaitingRooms.Add(waitingRoom);

        }
        public void ExtendFloor(int coordinate)
        {
            if (coordinate < 0)
            {
                this.Range = new Range(this.Range.XCoordinate + coordinate, this.Range.XCoordinate);
            }
            else
            {
                this.Range = new Range(this.Range.XCoordinate, this.Range.XCoordinate + coordinate);
            }

            this.Segments += Math.Abs(coordinate);
        }
        public enum ElevatorType
        {
            Passenger,
            Service,
            Express
        }

        public class ElevatorFactory
        {
            public IElevator GetElevator(ElevatorType elevatorType, int xCoordinateRight, int floorNumber)
            {
                switch (elevatorType)
                {
                    case ElevatorType.Passenger:
                        return new PassengerElevator(xCoordinateRight, floorNumber);
                    //case ElevatorType.Service:
                    //    return new ServiceElevator(xCoordinateRight);
                    //case ElevatorType.Express:
                        //return new ExpressElevator(xCoordinateRight);
                    default:
                        throw new NotSupportedException();
                }
            }
        }
    }

}
