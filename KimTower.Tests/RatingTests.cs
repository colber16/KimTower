namespace KimTower.Tests
{
    using NUnit.Framework;
    using KimTower.Data;

    [TestFixture]
    public class RatingTests
    {
        [TestCase(ExpectedResult = true)]
        public bool InitialTowerHasOneStarRating()
        {
            var tower = new Tower();
            return tower.Rating.OneStar;
                 
        }
    }
}
