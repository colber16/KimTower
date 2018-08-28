namespace KimTower.Data.Transportation.Elevators
{
    public class ElevatorCar
    {
        public int Cost => 80000;

        public int Capacity = 21;

        public int FloorNumber { get; set; }

        public ElevatorCar(int floorNumber)
        {
            this.FloorNumber = floorNumber;
        }
    }
}