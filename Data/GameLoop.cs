
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
                var isProcessed = false;
                //eats first key
                if (Console.ReadKey(true).Key != ConsoleKey.DownArrow)
                {
                    var input = Console.ReadLine();
                    isProcessed = ProcessInput(input);
                }
                if (isProcessed)
                {
                    Update();
                    Render();
                }
                else
                {
                    Console.WriteLine("Input was not processed.");
                }
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
            //get new floor

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

                if (!IsValidPositionOnMap(x, x2, floorNumber))
                {
                    Console.WriteLine("Invalid position.");
                    return false;
                }

                var floor = GetExistingFloor(floorNumber);

                if (floor == null)
                {
                    var newFloor = new Floor(x, x2, floorNumber);

                    tower.Floors.Add(newFloor);

                    return true;
                }
                if (IsValidPositionInExistingFloor(x, x2, floor))
                {
                    //all positions
                    var position = GetNewFloorPosition(x, x2, floor);
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

                if (!IsRoomValidForFloor(room, floorNumber))
                {
                    Console.WriteLine("Invalid input");
                }
                else
                {
                    var floor = FloorCheck(x, room.Segments, floorNumber);

                    AddRoom(room, floor);
                }

            }
            return true;
            //need to validate if floor exist, maybe. . .
        }

        private bool IsFloorRequest(string[] inputs)
        {
            return inputs.Contains("f");
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
            if (!(room is Lobby))
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
        ////break up into get new coordinate maybe.
        //public bool IsValidSegment(int x, int x2, int floorNumber)
        //{
        //    if (IsValidPositionOnMap(x, x2, floorNumber))
        //    {
        //        foreach (var floor in tower.Floors)
        //        {
        //            if (floor.FloorNumber == floorNumber)
        //            {
        //                if (x < floor.Position.X)
        //                {
        //                    if (x2 <= floor.Position.X2)
        //                    {
        //                        floor.ExtendPosition(x, floor.Position.X2);
        //                    }
        //                    else
        //                    {
        //                        floor.ExtendPosition(x, x2);
        //                    }
        //                    return true;
        //                }
        //                else if (x > floor.Position.X && x2 > floor.Position.X2)
        //                {
        //                    floor.ExtendPosition(floor.Position.X, x2);
        //                    return true;
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Invalid floor Position");

        //                }
        //            }
        //        }

        //    }
        //    return false;
        //}
        //only call this if it is valid.
        public Position GetNewFloorPosition(int x, int x2, Floor floor)
        {
            
            if (x < floor.Position.X)
            {
                
                if(x2 > floor.Position.X2)
                {
                    return new Position(x, x2, floor.FloorNumber);
                }
                return new Position(x, floor.Position.X2, floor.FloorNumber);
                //if (x2 <= floor.Position.X2)
                //{
                //    return x;
                //}
                //else
                //{
                // return x2;
                //}
                //return x;
            }
            else 
            {
                return new Position(x, x2, floor.FloorNumber);
                //if(x2 > floor.Position.X2)
                //{
                  //  return x2;
               // }
            }
        }

        public Floor GetExistingFloor(int floorNumber)
        {
            foreach (var existingFloor in tower.Floors)
            {
                    if (existingFloor.FloorNumber == floorNumber)
                {
                        return existingFloor;
                }
            }
            return null;
        }
        //only invalid if x and x2 are contained in existing floor position.
        //else the floor can be extended.
        public bool IsValidPositionInExistingFloor(int x, int x2, Floor floor)
        {
            //wrong
            //return (x >= floor.Position.X && x2 >= floor.Position.X2);

            //if (x < floor.Position.X)
            //{
            //    if (x2 <= floor.Position.X2)
            //    {
            //        return true;
            //    }
            //    if(x = floor.Position.X)
            //    {
                    
            //    }
            //    return true;
            //}
            //else if (x > floor.Position.X && x2 > floor.Position.X2)
            //{
            //    return true;
            //}
            //return false;

            var count = 0;

            for (int i = floor.Position.X; i <= floor.Position.X2; i++)
            {
                

                if(x >= i)
                {
                    count++;
                    //don't want to keep checking this.
                }
                if(count > 0)
                {
                    i = floor.Position.X2;
                }
                if (x2 <= i)
                {
                    count++;
                }
            }
            if(count >=2)
            {
                return false;
            }
            return true;
        }

            //if (x < floor.Position.X)
            //{
            //    if (x2 <= floor.Position.X2)
            //    {
            //        GetNewPosition(x, floor.Position.X2, floorNumber);
            //    }
            //    else
            //    {
            //        GetNewPosition(x, x2, floorNumber);
            //    }
            //    return true;
            //}
            //else if (x > floor.Position.X && x2 > floor.Position.X2)
            //{
            //    GetNewPosition(floor.Position.X, x2, floorNumber);
            //    return true;
            //}
            //else
            //{
            //    Console.WriteLine("Invalid floor Position");
            //}
                    
                


        //    return false;
        //}
        public bool IsValidPositionOnMap(int x, int x2, int floorNumber)
        {
            if (x >= 0 && x2 <= 500)
            {
                if (floorNumber >= -10 && floorNumber <= 100)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
