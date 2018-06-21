using System;
namespace KimTower
{
    public class Person
    {
        public Person()
        {
        }

        public string Name { get; set; }

        public Position Position { get; set; }
    }

    public class Position
    {
        public int X { get; set; }

        public int Y { get; set; }
    }
}