
namespace KimTower.Data
{
    using System.Threading;

    public class Time
    {
        public Time(int totalMinutes)
        {
            this.TotalMinutes = totalMinutes;
        }

        public Time(int year, int quarter, Day day, int hour, int minute)
        {
            this.TotalMinutes = minute + (hour * 60) + (quarter * 3 * 24 * 60) + GetMinutesFromDay(day) + (year * 4 * 3 * 24 * 60);
        }

        public int Minute { get { return TotalMinutes % 60; } }

        public int TotalMinutes { get; private set; }

        public int Hour { get { return (TotalMinutes / 60) % 24; } }

        public Day Day { get { return GetDayFromMinutes(TotalMinutes); } }

        public int Quarter { get { return (TotalMinutes / (24 * 60 * 3) % 4); } }

        public int Year { get { return (TotalMinutes / (24 * 60 * 3 * 4)); } }

        public Day GetDayFromMinutes(int minutes)
        {
            var day = (minutes / (24 * 60) % 3);

            if (day == 0)
            {
                return Day.WeekdayOne;
            }
            if (day == 1)
            {
                return Day.WeekdayTwo;
            }
            else
            {
                return Day.Weekend;
            }
        }

        public int GetMinutesFromDay(Day day)
        {
            if (day == Day.WeekdayOne)
            {
                return 0;
            }
            if (day == Day.WeekdayTwo)
            {
                return 24 * 60;
            }
            else
            {
                return 48 * 60;
            }
        }
        public int RunTime()
        {
            this.TotalMinutes += 1442;
            return this.TotalMinutes;
        }

    }

    public enum Day
    {
        WeekdayOne,
        WeekdayTwo,
        Weekend
    }

}
