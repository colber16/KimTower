using System;
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
            this.FloorSpan = new FloorSpan(floor.FloorNumber, floor.FloorNumber + 1 );
        }
        public bool IsInUse() => WaitingRoom.Population > 0;

        public int GetPopulation()
        {
            
            if(this.WaitingRoom.Population % capacity == 0)
            {
                return capacity;
            }
            else
            {
                return this.WaitingRoom.Population % capacity;
            }
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
}
