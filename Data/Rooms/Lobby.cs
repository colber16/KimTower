
namespace KimTower.Data
{
    public class Lobby : Room, IRoom
    {
        static int segments = 4;
        static int cost = 1500;

        public int TotalSegments { get; private set; }

        public int Rent => 0;

        public Lobby(int x, int floorNumber) : base(segments, cost, x, floorNumber)
        {
            this.TotalSegments = segments;
        }
        public void ExtendSegments()
        {
            this.TotalSegments += segments;
        }

    }
}
