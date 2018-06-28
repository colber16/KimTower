using System;
namespace KimTower
{
    public interface IFloor
    {

        Range Range { get; set; }

        int ParentFloor { get; set; }

        int FloorNumber { get; }

        int MaintenanceCost { get; }

        int Segments { get; set; }

        bool IsBelowGround { get; set; }

    }
    public class Floor : IFloor
    {

        private int _segment;

        public Range Range { get; set; }

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

        public int MaintenanceCost { get { return 0; } }

        public int Segments
        {
            get { return _segment; }
            set
            {
                if (value <= 0)
                {
                    _segment = 1;
                }
                else
                {
                    _segment = value;
                }
            }
        }

        public int TotalSegments { get; private set; }

        public bool IsBelowGround { get; set; }


        public Floor(Range range, int parentFloor, int segments, bool isBelowGround)
        {
            this.Range = new Range(range.XCoordinate, range.XSecondCoordinate);
            this.ParentFloor = parentFloor;
            this.Segments = segments;
            this.IsBelowGround = isBelowGround;
        }
        public Floor()
        {

        }

        public void ExtendFloorToTheRight(int segments)
        {
            var newX = this.Range.XSecondCoordinate + segments;
            this.Range = new Range(this.Range.XCoordinate, newX);
            this.Segments += segments;
        }
        //TODO: Need an origin somewhere. Max and min position
        public void ExtendFloorToTheLeft(int segments)
        {
            var newX = this.Range.XCoordinate - segments;
            this.Range = new Range(newX, this.Range.XSecondCoordinate);
            this.Segments += segments;
        }
    }

    public class ConstructFloor 
    {
        public readonly int cost = 500;

        public Range Range { get; set; }

        public int ParentFloor { get; set; }

        public int FloorNumber { get; }

        public int Segments { get; set; }

        public bool IsBelowGround { get; set; }

        public int Cost { get { return -cost * this.Segments; } }

        public ConstructFloor(int startingPosition, int parentFloor, int segments, bool isBelowGround) 
        {
            this.Range = new Range(startingPosition, startingPosition + segments);
            this.ParentFloor = parentFloor;
            this.Segments = segments;
            this.IsBelowGround = isBelowGround;
            CreateMaintainableFloor(this.Range, parentFloor, segments, isBelowGround);
        }

        public Floor CreateMaintainableFloor(Range range, int parentFloor, int segments, bool isBelowGround)
        {
            return new Floor(range, parentFloor,segments,isBelowGround);
        }
    }

}
