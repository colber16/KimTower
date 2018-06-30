using System;
namespace KimTower
{
    public interface IFloor
    {

        Range Range { get; set; }

        int FloorNumber { get; }

        //int MaintenanceCost { get; }

        int Segments { get; set; }

        void ExtendFloor(int coordinate);
    }
    //people can be in lobbies
    public class Lobby : IFloor
    {
        public Range Range { get; set; }

        public int FloorNumber { get; set;}

        public int Segments { get; set; }

        public void ExtendFloor(int coordinate)
        {
            //copy pasta.  Maybe us an abstract class
            //needs to fill with lobby "room"
            if (coordinate < 0)
            {
                this.Range = new Range(this.Range.XCoordinate + coordinate, this.Range.XCoordinate);

            }
            else
            {
                this.Range = new Range(this.Range.XCoordinate, this.Range.XCoordinate + coordinate);
            }

            this.Segments += Math.Abs(coordinate);
        }
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
        //Combine these
        public void ExtendFloor(int coordinate)
        {
            if(coordinate < 0)
            {
                this.Range = new Range(this.Range.XCoordinate + coordinate, this.Range.XCoordinate);

            }
            else
            {
                this.Range = new Range(this.Range.XCoordinate, this.Range.XCoordinate + coordinate);
            }

            this.Segments += Math.Abs(coordinate);
        }
    }

}
