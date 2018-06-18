using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KimTower
{
    public class Time
    {
        public Time(int totalMinutes)
        {
            this.TotalMinutes = totalMinutes;
        }

        public Time(int year, int quarter, Day day, int hour, int minute)
        {
            this.TotalMinutes = minute + hour * 60 ;
        }

        public int Minute { get { return TotalMinutes % 60; } }

        public int TotalMinutes { get; private set; }

        public int Hour { get { return (TotalMinutes / 60) % 24; } }

        public Day Day { get;}

        public int Quarter { get { return (TotalMinutes / 60) % (24 * 3); } }

        public int Year { get { return (TotalMinutes / 60) % (24 * 3 * 4); } }
        

    }

    public enum Day
    {
        WeekdayOne,
        WeekdayTwo,
        Weekend
    }
}
