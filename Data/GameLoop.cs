
namespace KimTower.Data
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class GameLoop
    {
        Build build = new Build();
        Time time = new Time(0);
        public Tower tower = new Tower();

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
            ConsoleStuff.PrintGameStats(tower, time);
        }

        private void Update()
        {
            this.time = time.RunTime();

            tower.CollectRent(time);
        }

        public bool ProcessInput(string input)
        {
            var inputs = input.Split(" ");
            var desiredStructure = Convert.ToChar(inputs[0]);
            int floorNumber;
            int startX;

            int.TryParse(inputs[1], out floorNumber);

            var nullableStructure = ConsoleStuff.GetStructureFromInput(desiredStructure);

            if (nullableStructure == null)
            {
                Console.WriteLine("Invalid Structure.");
                return false;
            }
            var structure = (StructureTypes)nullableStructure;

            if(!ConsoleInputValidation.IsInputSortaValid(inputs, structure))
            {
                return false;
            }

            int.TryParse(inputs[2], out startX);

            if(!tower.IsLobbyBuilt())
            {
                if(!(structure is StructureTypes.Lobby))
                {
                    Console.WriteLine("Must Build Lobby first");
                    return false;
                }
            }
            if (structure is StructureTypes.Lobby || structure is StructureTypes.Floor)
            {
                int endX;

                if(inputs.Length > 3)
                {
                    int.TryParse(inputs[3], out endX);
                }
                else
                {
                    //lobby segments
                    endX = startX + 4;
                }
                return ProcessFloor(startX, endX, floorNumber, structure) != null;
            }
            if(structure is StructureTypes.Stairs)
            {
                return ProcessStairRequest(floorNumber);
            }
            else
            {
                if (IsLobbyFloor(floorNumber))
                {
                    return false;
                }
                return BuildRoom(structure, startX, floorNumber);
            }
           
        }

        public bool BuildRoom(StructureTypes structure, int startX, int floorNumber)
        {
            //But, . . .only Floors can have rooms
            IFloor floor;

            var room = GetRoom(structure, startX, floorNumber);
            floor = ProcessFloor(startX, startX + room.Segments, floorNumber, structure);

            ((Floor)floor).AddRoom(room);
            return true;

        }

        public IFloor ProcessFloor(int startX, int endX, int floorNumber, StructureTypes structure)
        {
            if (!IsValidFloorNumberAndRange(new Range(startX, endX), floorNumber, structure))
            {
                return null;
            }
            return GetExistingOrNewFloor(startX, endX, floorNumber, structure);

        }

        private IFloor GetExistingOrNewFloor(int startX, int endX, int floorNumber, StructureTypes structure)
        {
            var floor = GetExistingFloor(floorNumber);

            if (floor == null)
            {
                switch(structure)
                {
                    case StructureTypes.Floor:
                      
                        floor = new Floor(new Range(startX, endX));
                        break;

                    case StructureTypes.Lobby:
                        
                        floor = new Lobby(startX);
                        break;
                }

                tower.AddFloor(floor);
            }
            else
            {
                var range = floor.GetExtendedFloorRange(new Range(startX, endX));
                floor.ExtendRange(range);
            }

            return floor;
        }

        private bool IsValidFloorNumberAndRange(Range range, int floorNumber, StructureTypes structure)
        {
            if (!FloorValidation.IsValidSpaceOnMap(range, floorNumber))
            {
                Console.WriteLine("Invalid position within map.");
                return false;
            }

            if (IsLobbyFloor(floorNumber)  && (!(structure is StructureTypes.Lobby)))
            {
                Console.WriteLine("Lobby must be on first floor.");
                return false;
            }

            bool existingFloor = false;

            if (!tower.IsValidExistingFloorNumber(floorNumber))
            {
                if (!tower.IsNextFloorNumber(floorNumber))
                {
                    Console.WriteLine("Floor does not existing and preceding floor has not be created.");
                    return false;
                }
            }
            else
            {
                existingFloor = true;
            }


            if (existingFloor && FloorValidation.IsFloorRangePreexisting(range, tower.Floors[floorNumber]))
            {
                Console.WriteLine("Invalid position. Must be larger than current floor position");
                return false;
            }
            return true;
        }

        private bool ProcessStairRequest(int floorNumber)
        {
            var stairCount = tower.Floors[floorNumber].Stairs.Count;

            tower.Floors[floorNumber].AddStairs(floorNumber);
            tower.Floors[floorNumber + 1].AddStairs(floorNumber);

            return stairCount + 1 == tower.Floors[floorNumber].Stairs.Count;
        }

        public IRoom GetRoom(StructureTypes? desiredRoom, int x, int floorNumber)
        {
            switch (desiredRoom)
            {
                case StructureTypes.Office:
                    return new Office(x, floorNumber);
                case StructureTypes.Condo:
                    return new Condo(x, floorNumber);
                case StructureTypes.Restaurant:
                    return new Restaurant(x, floorNumber);

                default:
                    return null;
            }

        }

        private IFloor GetExistingFloor(int floorNumber)
        {
            if (!tower.IsValidExistingFloorNumber(floorNumber))
            {
                return null;

            }
            return tower.Floors[floorNumber];

        }

        public bool IsLobbyFloor(int floorNumber) => floorNumber == 0;
    }
}
