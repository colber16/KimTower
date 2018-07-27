
namespace KimTower.Data
{
    using System;
    using System.Linq;

    public class GameLoop
    {
        public void Run(Tower tower)
        {
            Build build = new Build();
            Time time = new Time(0);
            Clock clock = new Clock(time);
            while (true)
            {
                if (Console.ReadKey(true).Key != ConsoleKey.DownArrow)
                {
                    var input = Console.ReadLine();
                    ProcessInput(input, tower);
                }
               
                Update(time, tower);
                Render(tower, clock);

            }
        }

        private void Render(Tower tower, Clock clock)
        {
            for (int i = 0; i < tower.Floors.Count; i++)
            {
                Console.WriteLine($"Floors:{tower.Floors[i].FloorNumber}, Segments: {tower.Floors[i].Segments}, Rooms Count: {tower.Floors[i].Rooms.Count}");
                Console.WriteLine(clock.DisplayTime());
                Console.WriteLine($"Money: {tower.Floors[i].Ledger.TotalProfit}");

            }
        }

        private void Update(Time time, Tower tower)
        {
            time.RunTime();
            if(time.Day == Day.WeekdayTwo)
            {
                foreach(var floor in tower.Floors)
                {
                    foreach(var office in floor.Rooms)
                    {
                        if(office is Office)
                        {
                            floor.Ledger.TotalProfit += ((Office)office).PayRent();
                        }
                    }
                }
            }
        }

        private Floor FloorCheck(int segments, Tower tower, int floorNumber)
        {
            foreach (var floor in tower.Floors)
            {
                if (floor.FloorNumber == floorNumber)
                {
                    floor.ExtendSegments(segments);
                    return floor;

                }
            }

            var newFloor = new Floor(segments, floorNumber);

            tower.Floors.Add(newFloor);

            return newFloor;

        }

        private void ProcessInput(string input, Tower tower)
        {
            
            var inputs = input.Split(" ");
            var desiredRoom = inputs[0];
            var floorNumber = Int32.Parse(inputs[1]);

            IRoom room = DetermineRoomType(desiredRoom);

            var floor = FloorCheck(room.Segments, tower, floorNumber);

            AddRoom(room, floor);
        }

        private void AddRoom(IRoom room, Floor floor)
        {
            if((!floor.Rooms.Any(l => l is Lobby) && room is Lobby) || !(room is Lobby))
            {
                floor.Rooms.Add(room);
            }
            else
            {
                ((Lobby)room).ExtendSegments();
            }
        }

        private IRoom DetermineRoomType(string desiredRoom)
        {
            if (desiredRoom == "l")
            {
                return new Lobby();
            }
            if (desiredRoom == "o")
            {
                return new Office();
            }
            throw new NotImplementedException();
        }

    }
}
