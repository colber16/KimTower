
namespace KimTower.Tests
{
    using KimTower.Data;
    using NUnit.Framework;

    [TestFixture]
    public class GlobalPropertiesTests
    {
        [Test, TestCase(StructureTypes.Lobby, ExpectedResult = 1980000)]
        [TestCase(StructureTypes.Office, ExpectedResult = 1960000)]
        public int SubtractConstructionCostsReducesMoneyBalance(StructureTypes structure)
        {
            var globalProperties = new GlobalProperties();
            globalProperties.SubtractConstructionCosts(structure);
            return globalProperties.Money;
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
