
namespace KimTower.Data
{
    public struct Range
    {
        public int StartX { get; set;}

        public int EndX { get; set; }

        public Range(int startX, int endX)
        {
            this.StartX = startX;
            this.EndX = endX;
        }
    }
}
