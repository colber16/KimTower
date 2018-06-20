namespace KimTower
{
    public class MapWindow
    {
        public MapWindow()
        {
            
        }
        //TODO: Edit window. . . 
        //public Edit {}

        public RoomEvaluation RoomEvaluation { get; set; }

        public PricingEvaluation PricingEvaluation { get; set;}

        public HotelEvaluation HotelEvaluation { get; set; }
    }

    public enum RoomEvaluation
    {
        Excellent,
        Good,
        Terrible,

    }

    public enum PricingEvaluation
    {
        High,
        Average,
        Low,
        VeryLow
    }

    public enum HotelEvaluation
    {
        Clean,
        Dirty
    }
}