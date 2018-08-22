
namespace KimTower.Tests
{
    using KimTower.Data;
    using NUnit.Framework;

    [TestFixture]
    public class GlobalPropertiesTests
    {
        [Test, TestCase(StructureTypes.Lobby,false, 2, 1, 9,  ExpectedResult = 1960000)]
        [TestCase(StructureTypes.Office, false, 2, 1, 7, ExpectedResult = 1957000)]
        public int SubtractConstructionCostsReducesMoneyBalance(StructureTypes structure, bool isExistingFloor, int floorNumber, int startX, int endX)
        {
            var range = new Range(startX, endX);
            //var globalProperties = new GlobalProperties();
            var gameLoop = new GameLoop();
            var cost = gameLoop.PayForStructure(structure, isExistingFloor, floorNumber, range); //just room just floor or Room plus floor
           
            return gameLoop.GlobalProperties.Money;
        }

        [Test, TestCase(200000, ExpectedResult = 2200000)]
        [TestCase(1000000, ExpectedResult = 3000000)]
        public int AddIncomeIncreasesMoneyBalance(int profits)
        {
            var globalProperties = new GlobalProperties();
            globalProperties.AddIncome(profits);
            return globalProperties.Money;
        }
       
        [Test, TestCase(200000, ExpectedResult = 1800000)]
        [TestCase(1000000, ExpectedResult = 1000000)]
        [TestCase(0, ExpectedResult = 2000000)]
        public int SubtractMaintenanceCostsDecreasesMoneyBalance(int cost)
        {
            var globalProperties = new GlobalProperties();
            globalProperties.SubtractMaintenanceCosts(cost);
            return globalProperties.Money;
        }

    }
}
