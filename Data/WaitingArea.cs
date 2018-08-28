namespace KimTower.Data
{
    public class WaitingArea
    {
        public int FloorNumber { get; set; }

        public int Population { get; }

        public int Capacity { get; }

        public WaitingArea(int ElevatorCapacity)
        {
            this.Capacity = ElevatorCapacity * 4;
        }
    }
}