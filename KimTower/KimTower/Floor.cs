using System;
namespace KimTower
{
    public interface IFloor
    {
        
        Position Position { get; set; }

        int ParentFloor { get; set; }

        int FloorNumber { get; }

        int MaintenanceCost { get; }

        int Segments { get; set; }
        //total width of the floor
        int TotalSegments { get; }

        bool IsBelowGround { get; set; }

        int Cost { get; }

    }
    public class Floor : IFloor
    {
        public readonly int cost = 500;

        private int _segment;

        public Position Position { get; set; }

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

        public int Cost { get { return - cost * this.Segments; } }

        public Floor(int startingPosition, int parentFloor, int segments, int totalSegments, bool isBelowGround)
        {
            this.Position = new Position(startingPosition, startingPosition + segments);
            this.TotalSegments = segments + totalSegments;
            this.ParentFloor = parentFloor;
            this.Segments = segments;
            this.IsBelowGround = isBelowGround;
        }
        public Floor()
        {
            
        }

        public Floor ExtendFloorToTheRight(int segments)
        {
            var newX = this.Position.XSecondCoordinate + segments;
            this.Position = new Position(this.Position.XCoordinate, newX);
            this.TotalSegments += segments;
            return new Floor();
        }
        //TODO: Need an origin somewhere. Max and min position
        public Floor ExtendFloorToTheLeft(int segments)
        {
            var newX = this.Position.XCoordinate - segments;
            this.Position = new Position(newX, this.Position.XSecondCoordinate);
            this.TotalSegments += segments;
            return new Floor();
        }
    }
    /// <summary>
    /// Lobbies can only be placed on the 1st floor
    /// </summary>
    //public class Lobby : IFloor
    //{
    //    public Lobby()
    //    {
    //    }

    //    public Position Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    //    public int ParentFloor { get { return 0; } }
    //    public int MaintenanceCost { get;  }
    //    public int Segments { get => throw new NotImplementedException();  }
    //    public bool IsBelowGround { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    //    public int Cost { get => throw new NotImplementedException();  }
    //    public int FloorNumber { get => throw new NotImplementedException(); }
    //    int IFloor.ParentFloor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    //    int IFloor.MaintenanceCost { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    //}

}
