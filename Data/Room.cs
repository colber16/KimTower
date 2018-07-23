namespace KimTower
{
    using System.Collections.Generic;

    public class Room
    {
        public List<Person> People { get; set; }

        public Room()
        {
            this.People = new List<Person>();
        }
    }
}   