using System;
namespace KimTower
{
    public class Person 
    {
        
        public string Name { get; set; }

        public int Position { get; set; }
        //New type or flag??
        public bool IsVIP { get; set; }

        public Person(string name, int position)
        {
            this.Name = name;
            this.Position = position;

        }
    }

    public class ServicePerson : Person
    {
        public ServicePerson(string name, int position) : base(name, position)
        {
            this.Name = name;
            this.Position = position;
        }

    }
}