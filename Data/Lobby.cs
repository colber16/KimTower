
namespace KimTower.Data
{
    using KimTower.Data.Rooms;

    public class Lobby : BasicFloor, IFloor
    {
        static int segments = StructureInfo.lobbyInfo.Segments;
        static int cost = StructureInfo.lobbyInfo.ConstructionCost;

        public Lobby(int x) : base(new Range(x, x + segments))
        {
           
        }
     
    }
}
