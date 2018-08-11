
namespace KimTower.Tests
{
    using KimTower.Data;
    using NUnit.Framework;

    [TestFixture]
    public class GlobalPropertiesTests
    {
        [Test, TestCase(StructureTypes.Lobby, ExpectedResult = 1980000)]
        [TestCase(StructureTypes.Office, ExpectedResult = 1960000)]
        public int SubtractCostForStructureReducesMoneyBalance(StructureTypes structure)
        {
            var globalProperties = new GlobalProperties();
            globalProperties.SubtractCostForStructures(structure);
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
       
    }
}
