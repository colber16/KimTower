
namespace KimTower.Data
{
    public class Lobby : BasicFloor, IFloor
    {
        static int segments = 4;
        static int cost = 1500;

        public Lobby(int x) : base(new Range(x, x + segments))
        {
           
        }
     
    }
}
