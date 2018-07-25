
namespace KimTower.Data
{
    using System;
    using System.Linq;

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
                Console.ReadLine();
            }
        }

        private void Render(Tower tower)
        {
            Console.WriteLine($"Floors:{tower.Floors[0].FloorNumber}, Segments: {tower.Floors[0].Segments}");
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
                if(tower.Floors.Count == 0)
                {
                    tower.AddInitialLobby();
                }
                else
                {
                    tower.Floors[0].ExtendSegments(4);

                    foreach(var room in tower.Floors[0].Rooms)
                    {
                        if(room is Lobby)
                        {
                            ((Lobby)room).ExtendSegments();
                        }
                    }
                }

            }
        }
    }
}
