
namespace KimTower.Data
{
    public class Lobby : BasicFloor
    {
        static int segments = 4;
        static int cost = 1500;

        public Lobby(int x, int floorNumber) : base(new Range(x, x + segments), floorNumber)
        {
           
        }
     
    }
}
