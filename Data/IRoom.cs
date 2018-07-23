namespace KimTower
{
    using System.Collections.Generic;

    public interface IRoom
    {
        List<Person> People { get; set; }
    }
}