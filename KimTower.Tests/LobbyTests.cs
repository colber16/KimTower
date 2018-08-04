
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
    }
}
