
namespace KimTower.Tests
{
    using System;
    using NUnit.Framework;
    using KimTower.Data;
    using System.Collections.Generic;

    [TestFixture]
    public class PositionTests
    {
        [Test]
        [TestCaseSource(nameof(PositionAdd))]
        public Position PositionAddition(Position p1, Position p2)
        {
            return p1 + p2;
        }

        public static List<TestCaseData> PositionAdd = new List<TestCaseData>
        {
            new TestCaseData(new Position(1, 2, 1), new Position(0, 20, 1)).Returns(new Position(1, 22, 1)),


        };

        [Test]
        [TestCaseSource(nameof(PositionSub))]
        public (Position? p1, Position? p2) PositionSubtraction(Position p1, Position p2)
        {
            return p1 - p2;
        }

        public static List<TestCaseData> PositionSub = new List<TestCaseData>
        {
            new TestCaseData(new Position(1, 20, 1), new Position(2, 18, 1)).Returns((new Position(1, 2, 1), new Position(18, 22, 1)))


        };
    }
}
