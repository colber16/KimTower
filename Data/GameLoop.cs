
namespace KimTower.Data
{
    using System;

    public class GameLoop
    {
      public void Run(string input, Tower tower)
        {
            Build build = new Build();

            while(true)
            {
                ProcessInput(input, tower);
               // Update();
                Render(tower);
            }
        }

        private void Render(Tower tower)
        {
            Console.WriteLine($"Floors:{tower.Floors[0].FloorNumber}");
        }

        private void Update()
        {
            throw new NotImplementedException();
        }
        private void UpdateFloor()
        {
            
        }

        private void ProcessInput(string input, Tower tower)
        {
            if(input == "l")
            {
                tower.AddLobby();
            }
        }
    }
}
