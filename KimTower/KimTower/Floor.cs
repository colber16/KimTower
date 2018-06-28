using System;
namespace KimTower
{
    public interface IFloor
    {

        Range Range { get; set; }

        int FloorNumber { get; }

        //int MaintenanceCost { get; }

        int Segments { get; set; }

    }
    //floors can not be deleted
    public class Floor : IFloor
    {
        public Range Range { get; set; }

        //public int MaintenanceCost { get { return 0; } }

        public int Segments { get; set; }

        public bool IsBelowGround { get; set; }

        public int ParentFloor { get; set; }
        //Should lobby have a parent floor of 0?
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


        public Floor(Range range, int segments, int parentfloor, bool isBelowGround)
        {
            this.ParentFloor = parentfloor;
            this.Range = new Range(range.XCoordinate, range.XSecondCoordinate);
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

}
