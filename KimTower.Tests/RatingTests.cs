namespace KimTower.Tests
{
    using NUnit.Framework;
    using KimTower.Data;

    [TestFixture]
    public class RatingTests
    {
        [TestCase(ExpectedResult = true)]
        public bool InitialTowerHasOneStarRatingSetToTrue()
        {
            var tower = new Tower();
            return tower.Rating.OneStar;
                 
        }
        [TestCase(ExpectedResult = false)]
        public bool InitialTowerHasTwoStarRatingSetToFalse()
        {
            var tower = new Tower();
            return tower.Rating.TwoStar;

        }
    }
}
