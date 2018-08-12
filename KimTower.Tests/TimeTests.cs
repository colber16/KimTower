
namespace KimTower.Tests
{
    using NUnit.Framework;
    using KimTower.Data;

    [TestFixture]
    public class TimeTests
    {
        [Test]
        [TestCase(1, 2, Day.WeekdayOne, 12, 30)]
        [TestCase(2, 1, Day.WeekdayTwo, 6, 0)]
        [TestCase(4, 3, Day.Weekend, 18, 45)]
        [TestCase(10, 0, Day.WeekdayOne, 0, 0)]
        public void MinuteGetter(int year, int quarter, Day day, int hour, int minute)
        {
            var time = new Time(year, quarter, day, hour, minute);

            Assert.AreEqual(time.Minute, minute);
        }

        [Test]
        [TestCase(1, 2, Day.WeekdayOne, 12, 30)]
        [TestCase(2, 1, Day.WeekdayTwo, 6, 0)]
        [TestCase(4, 3, Day.Weekend, 18, 45)]
        [TestCase(10, 0, Day.WeekdayOne, 0, 0)]
        public void HourGetter(int year, int quarter, Day day, int hour, int minute)
        {
            var time = new Time(year, quarter, day, hour, minute);

            Assert.AreEqual(time.Hour, hour);
        }

        [Test]
        [TestCase(1, 2, Day.WeekdayOne, 12, 30)]
        [TestCase(2, 1, Day.WeekdayTwo, 6, 0)]
        [TestCase(4, 3, Day.Weekend, 18, 45)]
        [TestCase(10, 0, Day.WeekdayOne, 0, 0)]
        public void DayGetter(int year, int quarter, Day day, int hour, int minute)
        {
            var time = new Time(year, quarter, day, hour, minute);

            Assert.AreEqual(time.Day, day);
        }

        [Test]
        [TestCase(1, 2, Day.WeekdayOne, 12, 30)]
        [TestCase(2, 1, Day.WeekdayTwo, 6, 0)]
        [TestCase(4, 3, Day.Weekend, 18, 45)]
        [TestCase(10, 0, Day.WeekdayOne, 0, 0)]
        public void QuarterGetter(int year, int quarter, Day day, int hour, int minute)
        {
            var time = new Time(year, quarter, day, hour, minute);

            Assert.AreEqual(time.Quarter, quarter);
        }

        [Test]
        [TestCase(1, 2, Day.WeekdayOne, 12, 30)]
        [TestCase(2, 1, Day.WeekdayTwo, 6, 0)]
        [TestCase(4, 3, Day.Weekend, 18, 45)]
        [TestCase(10, 0, Day.WeekdayOne, 0, 0)]
        public void YearGetter(int year, int quarter, Day day, int hour, int minute)
        {
            var time = new Time(year, quarter, day, hour, minute);

            Assert.AreEqual(time.Year, year);
        }
    }
}
