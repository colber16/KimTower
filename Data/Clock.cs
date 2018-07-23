using System;
using System.Threading;

namespace KimTower
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
                DisplayTime(time);
            }
        }
        public string DisplayTime(Time time)
        {
            return $"{time.Hour} : {time.Minute}  {time.Day}";
        }
    }
}
