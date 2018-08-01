
namespace KimTower.Data
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class GameLoop
    {
        Build build = new Build();
        Time time = new Time(0);
        Tower tower = new Tower();

        public void Run()
        {
            ConsoleStuff.PrintTitle();

            var play = true;
            var newInput = true;

            while (play)
            {
                var isProcessed = false;

                if (newInput)
                {
                    ConsoleStuff.PrintInputRequest();

                    var input = Console.ReadLine();

                    isProcessed = ProcessInput(input);

                }

                if (isProcessed || !newInput)
                {
                    Update();
                    Render();
                }
                else
                {
                    Console.WriteLine("Input was not processed.");
                }

                ConsoleStuff.PrintContinueRequest();

                ConsoleStuff.ProcessContinueInput(ref play, ref newInput);
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

            CollectRent();
        }

        private void CollectRent()
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

        private Floor FloorCheck(int x, int segments, int floorNumber)
        {
            foreach (var floor in tower.Floors)
            {
                if (floor.FloorNumber == floorNumber)
                {
                    floor.ExtendSegments(segments);
                    return floor;

                }
            }
            return GetNewFloor(x, segments, floorNumber);

        }

        private Floor GetNewFloor(int x, int x2, int floorNumber)
        {
            var newFloor = new Floor(x, x2, floorNumber);

            tower.Floors.Add(newFloor);

            return newFloor;
        }

        private bool ProcessInput(string input)
        {

            var inputs = input.Split(" ");
            var desiredRoom = inputs[0];
            int floorNumber;
            int x;
            Floor floor;

            int.TryParse(inputs[1], out floorNumber);

            if (inputs.Length < 3)
            {
                Console.WriteLine("Invalid input.");
                return false;
            }

            int.TryParse(inputs[2], out x);

            if (IsFloorRequest(inputs))
            {
                int.TryParse(inputs[3], out int x2);

                if (!FloorValidation.IsValidPositionOnMap(x, x2, floorNumber))
                {
                    Console.WriteLine("Invalid position.");
                    return false;
                }

                 floor = tower.GetExistingFloor(floorNumber);

                if (floor == null)
                {
                    var newFloor = new Floor(x, x2, floorNumber);

                    tower.Floors.Add(newFloor);

                    return true;
                }
                if (FloorValidation.IsValidPositionInExistingFloor(x, x2, floor))
                {
                    //all positions
                    var position = floor.GetNewFloorPosition(x, x2);
                    floor.ExtendPosition(position);
                    return true;
                }
                Console.WriteLine("Invalid position.");
                return false;
            }

            if (IsStairRequest(inputs))
            {
                var bottomFloor = tower.Floors.SingleOrDefault(f => f.FloorNumber == floorNumber);
                bottomFloor.Stairs.Add(new StairCase(floorNumber));

                var topFloor = tower.Floors.SingleOrDefault(f => f.FloorNumber == bottomFloor.FloorNumber + 1);
                topFloor.Stairs.Add(new StairCase(bottomFloor.FloorNumber));
            }
            else
            {
                IRoom room = DetermineRoomType(desiredRoom);

                if (!FloorValidation.IsRoomValidForFloor(room, floorNumber))
                {
                    Console.WriteLine("Invalid input");
                }
                else
                {
                    floor = FloorCheck(x, room.Segments, floorNumber);

                    AddRoom(room, floor);
                }

            }
            return true;
            //need to validate if floor exist, maybe. . .
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
