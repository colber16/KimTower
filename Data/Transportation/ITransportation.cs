namespace KimTower.Data.Transportation
{
    public interface ITransportation
    {
        Range Range { get; set; }

        int TopFloor { get; set; }

        int BottomFloor { get; set; }

        void SetBottomAndTopFloors(int bottom, int top);
    }
}