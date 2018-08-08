
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
            var lobby = new Lobby(0, 1);
            lobby.ExtendSegments();
            return lobby.TotalSegments;
        }

        [Test, TestCase("f 1 2 8",ExpectedResult = false)]
        public bool ReturnsFalseWhenLobbyIsNotBuilt(string input)
        {
            var gameLoop = new GameLoop();
            return gameLoop.ProcessInput(input);

        }
        [Test, TestCase("l 1 2 8", ExpectedResult = true)]
        public bool ReturnsTrueWhenLobbyIsRequested(string input)
        {
            var gameLoop = new GameLoop();
            return gameLoop.ProcessInput(input);

        }
    }
}
