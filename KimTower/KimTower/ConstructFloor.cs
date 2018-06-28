//namespace KimTower
//{
//    public class ConstructFloor
//    {

//        private int _segment;

//        public readonly int cost = -500;

//        public Range Range { get; set; }

//        public int ParentFloor { get; set; }




//        public int Segments
//        {
//            get { return _segment; }
//            set
//            {
//                if (value <= 0)
//                {
//                    _segment = 1;
//                }
//                else
//                {
//                    _segment = value;
//                }
//            }
//        }

//        public bool IsBelowGround { get; set; }

//        public int Cost { get { return cost * this.Segments; } }

//        public ConstructFloor(int startingPosition, int parentFloor, int segments, bool isBelowGround)
//        {
//            this.Range = new Range(startingPosition, startingPosition + segments);
//            this.ParentFloor = parentFloor;
//            this.Segments = segments;
//            this.IsBelowGround = isBelowGround;
//            CreateMaintainableFloor(this.Range, FloorNumber, segments);
//        }

//        public Floor CreateMaintainableFloor(Range range, int floorNumber, int segments)
//        {
//            return new Floor(range, floorNumber, segments);
//        }
//    }

//}
