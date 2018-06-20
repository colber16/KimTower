using System;
namespace KimTower
{
    public class Person
    {
        public Person()
        {
        }

        public string Name { get; set; }

        public Location Location { get; set; }
    }
    // multiples of all of these. . .
    public enum Location
    {
        OutsideTower,
        WaitingForElevator,
        WaitingForEscaltor,
        WaitingForStairs,
        OnStairs,
        OnElevator,
        OnEscaltor,
        Office,
        Condo,
        Restaurant

    }
}
