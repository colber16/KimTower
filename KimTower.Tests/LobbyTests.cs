
namespace KimTower.Tests
{
    using NUnit.Framework;
    using KimTower.Data;

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

        [Test, TestCase("f 1 2 ",ExpectedResult = false)]
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

    }
}
