using System;
using System.Threading;

namespace KimTower.Data
{
    public class Clock
    {
        public Clock(Time time)
        {
            
        }
        public void RunClock(Time time)
        {
            while(true)
            {
                time.RunTime();
                Console.WriteLine(DisplayTime(time));
            }
        }
        public string DisplayTime(Time time)
        {
            return $"{time.Hour} : {time.Minute}  {time.Day}";
        }
    }
}
