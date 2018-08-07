
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

        public static Range operator +(Range r1, Range r2)
        {
            return new Range(r1.StartX + r2.EndX, r1.EndX + r2.EndX);
        }

        public static Range operator -(Range r1, Range r2)
        {
            return new Range(r1.StartX - r2.EndX, r1.EndX - r2.EndX);
        }
    }
}
