
namespace KimTower.Data
{
    using System;
    using System.Linq;

    public class GameLoop
    {
        Build build = new Build();
        Time time = new Time(0);
        Tower tower = new Tower();

        public void Run()
        {
            while (true)
            {
                if (Console.ReadKey(true).Key != ConsoleKey.DownArrow)
                {
                    var input = Console.ReadLine();
                    ProcessInput(input, tower);
                }
                Update();
                Render();

            }
        }

        private void Render()
        {
            for (int i = 0; i < tower.Floors.Count; i++)
            {
                Console.WriteLine($"Floor Number:{tower.Floors[i].FloorNumber}, Segments: {tower.Floors[i].Segments}, Rooms Count: {tower.Floors[i].Rooms.Count}");

            }

            Console.WriteLine(time.ToString());
            Console.WriteLine($"Money: {tower.Ledger.TotalProfit}");
        }

        private void Update()
        {
            this.time = time.RunTime();

            CollectRent(time, tower);
        }

        private void CollectRent(Time time, Tower tower)
        {
            if (time.Day == Day.WeekdayTwo)
            {
                foreach (var floor in tower.Floors)
                {
                    foreach (var room in floor.Rooms)
                    {
                        if (room is Office)
                        {
                            floor.IsOccupied((Office)room, tower);
                            if (((Office)room).Occupied)
                            {
                                floor.Ledger.TotalProfit += ((Office)room).PayRent();
                            }

                        }
                    }
                }
            }
            tower.UpdateLedger();
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

            if(!IsStairRequest(inputs))
            {
                IRoom room = DetermineRoomType(desiredRoom);

                if (!IsRoomValidForFloor(room, floorNumber))
                {
                    Console.WriteLine("Invalid input");
                }
                else
                {
                    var floor = FloorCheck(room.Segments, tower, floorNumber);

                    AddRoom(room, floor); 
                }
            }
            else
            {
                var bottomFloor = tower.Floors.SingleOrDefault(f => f.FloorNumber == floorNumber);
                bottomFloor.Stairs.Add(new StairCase(floorNumber));

                var topFloor = tower.Floors.SingleOrDefault(f => f.FloorNumber == bottomFloor.FloorNumber + 1);
                topFloor.Stairs.Add(new StairCase(bottomFloor.FloorNumber));
            }
            //need to validate if floor exist, maybe. . .

        }

        private bool IsStairRequest(string[] inputs)
        {
            return inputs.Contains("s");
        }

        private void AddRoom(IRoom room, Floor floor)
        {
            if (room is Lobby)
            {
                if ((!floor.Rooms.Any(l => l is Lobby)))
                {
                    ((Lobby)room).ExtendSegments();
                }
                else
                {
                    floor.Rooms.Add(room);
                }
            }
            else
            {
                floor.Rooms.Add(room);
            }
        }

        public bool IsRoomValidForFloor(IRoom room, int floorNumber)
        {
            if (floorNumber == 1)
            {
                if (room is Lobby)
                {
                    return true;
                }
                return false;
            }
            if(!(room is Lobby))
            {
                return true;
            }
            return false;
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
