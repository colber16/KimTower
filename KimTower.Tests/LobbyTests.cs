
namespace KimTower.Tests
{
    using NUnit.Framework;
    using KimTower.Data;
    using KimTower.Data.Floors;

    [TestFixture]
    public class LobbyTests
    {
        [Test, TestCase(ExpectedResult = 8)]
        public int TotalSegmentsIncrease()
        {
            var lobby = new Lobby(1);
            lobby.ExtendRange(new Range(1, 9));
            return lobby.GetSegments();
        }

        [Test, TestCase("f 1 2 ", ExpectedResult = false)]
        public bool ReturnsFalseWhenLobbyIsNotBuilt(string input)
        {
            var gameLoop = new GameLoop();
            return gameLoop.ProcessInput(input);

        }
        [Test, TestCase("l 0 2 ", ExpectedResult = true)]
        public bool ReturnsTrueWhenLobbyIsRequested(string input)
        {
            var gameLoop = new GameLoop();
            return gameLoop.ProcessInput(input);

        }
        //[Test,TestCase("l 0 0", "l 0 10", ExpectedResult =)]
        //public int ConstructionCostsAreChargedPerSegment(string input1, string input2)
        //{
        //    var gameLoop = new GameLoop();
        //    gameLoop.ProcessInput(input1);
        //    gameLoop.ProcessInput(input2);
        //}

        [Test]
        public void ChargesForAllSegments()
        {
            var tower = new Tower();
            var builder = new Builder();
            var globalProperties = new GlobalProperties();
            var existingFloor = new Lobby(0);
            tower.AddFloor(existingFloor);

           // builder.BuildFloor(new Range(0, 20), 0, StructureTypes.Lobby, true, tower);

            var range = new Range(0,20);
            var gameLoop = new GameLoop();
            var cost = gameLoop.DetermineCost(StructureTypes.Lobby, false, 0, range); //just room just floor or Room plus floor

            gameLoop.IsBalanceSufficient(cost);
            globalProperties.SubtractConstructionCosts(cost);
            Assert.That(globalProperties.Money, Is.EqualTo(1900000));

        }

    }

}
