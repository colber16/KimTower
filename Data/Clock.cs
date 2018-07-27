using System;
using System.Threading;

namespace KimTower.Data
{
    public class Clock
    {
        public Time Time { get; set; 
        }
        public Clock(Time time)
        {
            this.Time = time;
        }
        public void RunClock(Time time)
        {
            while(true)
            {
                time.RunTime();
                Console.WriteLine(DisplayTime());
            }
        }
        public string DisplayTime()
        {
            return $"{this.Time.Hour} : {this.Time.Minute}  {this.Time.Day}";
        }
    }
}
