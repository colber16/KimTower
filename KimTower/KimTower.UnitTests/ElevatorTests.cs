using System;
using NUnit.Framework;
namespace KimTower.UnitTests
{
    public class ElevatorTests
    {
        [Test]
        public void ElevatorTest()
        {
            var ele = new PassengerElevator(2, 4);
            Assert.That(ele.InUse);
        }
    }
}
