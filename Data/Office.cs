
namespace KimTower.Data
{
    using System;
    using System.Collections.Generic;

    public class Office : IRoom 
    {
        public List<Person> People { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Office()
        {
        }

    }
}
