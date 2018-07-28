namespace KimTower.Data
{
    using System.Collections.Generic;

    public interface IRoom
    {
        List<Person> People { get; set; }
        int Segments { get; }
       
    }
}