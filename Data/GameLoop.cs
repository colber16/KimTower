
namespace KimTower.Data
{
    using System;
    public class GameLoop
    {
      public void Run(Tower tower)
        {
            Build build = new Build();

            while(true)
            {
                StartTime();
                //ProcessInput(tower);
                //DisplayTowerStats(tower);
            }
        }

        private void StartTime()
        {
            var time = new Time(0);
            var clock = new Clock(time);
            clock.RunClock(time);
        }

        private void ProcessInput(Tower tower)
        {
            throw new NotImplementedException();
        }
    }
}
