namespace KimTower.Tests
{
    using NUnit.Framework;
    using KimTower.Data;

    [TestFixture]
    public class RatingTests
    {
        [TestCase(ExpectedResult = Stars.One)]
        public Stars InitialTowerHasOneStarRatingSetToTrue()
        {
            var tower = new Tower();
            return tower.Rating.Stars;
                 
        }

        [TestCase(ExpectedResult = "One")]
        public string RatingToStringReturnsString()
        {
            var tower = new Tower();
            var rating = tower.Rating.Stars.ToString();
            return rating;

        }
    }
}
