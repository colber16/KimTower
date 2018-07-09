using System;
using NUnit.Framework;
namespace KimTower.UnitTests
{
    public class ElevatorTests
    {
        [Test]
        public void ElevatorTest()
        {
            //var shaft = new Shaft()
            var car = new Car();
            Assert.AreEqual(20, car.Capacity);
        }
    }
}
