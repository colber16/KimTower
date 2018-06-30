using System;
namespace KimTower
{
    public interface IRoom
    {

        bool Occupied { get; set; }

        //int MaintenanceCost { get; set; }
        /// <summary>
        /// Gets the capacity. Which is used in tower population
        /// </summary>
        /// <value>The capacity.</value>
        int Capacity { get; }
        /// <summary>
        /// Current population of people.
        /// </summary>
        /// <value>The population.</value>
        int Population { get; set; }

        int IsLit { get; set; }

        //int ConstructionCost { get; set; }

        Range Position { get; set; }

        int FloorNumber { get; set; }

        //int Revenue { get; set; }

        int Segements { get; }
       

    }
    public class Office : IRoom
    {
        private int segments = 9;
        private int capacity = 6;
       
        public bool Occupied { get; set; }
        public int Capacity => capacity;
        public int Population { get; set; }
        public int IsLit { get; set; } //set by time
        public Range Position { get; set; }
        public int FloorNumber { get; set; }

        public int Segements => segments;

        public Office(Floor floor)
        {
            this.FloorNumber = floor.FloorNumber;
        }
    }

}
