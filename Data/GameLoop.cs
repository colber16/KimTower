
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

            //validate floor number
            if(!tower.IsValidExistingFloorNumber(floorNumber))
            {
                if(!tower.IsNextFloorNumber(floorNumber))
                {
                    Console.WriteLine("What the heck is this floor number.");
                    return false;
                }
                //create floor
            }
            //get floor
            //if (floorNumber != tower.SetFloorNumber())
            //{
            //    Console.WriteLine("Incorrect floor number.");
            //    return false;

            //}
            var structure = ConsoleStuff.GetStructureFromInput(desiredStructure);

            if(!IsInputSortaValid(inputs, structure))
            {
                return false;
            }

            int.TryParse(inputs[2], out startX);

            if(!IsLobbyBuilt())
            {
                if(!(structure is StructureTypes.Lobby))
                {
                    return false;
                }
            }
            return BuildStructure(structure, startX, floorNumber, inputs);

        }

        public bool IsLobbyBuilt()
        { 
            if (!tower.HasLobby())
            {
                Console.WriteLine("Must create lobby first");
                return false;
            }
            return true;
        }


        public bool BuildStructure(StructureTypes? structure, int startX, int floorNumber, string[] inputs)
        {
            Floor floor;

            switch (structure)
            {
                case StructureTypes.Floor:
                    int.TryParse(inputs[3], out int endX);
                    return ProcessFloor(new Range(startX, endX), floorNumber);

                case StructureTypes.Lobby:
                    var lobby = GetRoom(structure, startX, floorNumber);
                    floor = GetExistingFloor(new Range(startX, startX + lobby.Segments), floorNumber);

                    if(!floor.IsLobbyFloor())
                    {
                        Console.WriteLine("Lobby must be on first floor.");
                        return false;
                    }
                    if(!floor.HasLobby())
                    {
                        floor.AddRoom(lobby);
                        tower.AddFloor(floor);
                    }
                    else
                    {
                        var existingLobby = floor.Rooms.SingleOrDefault(l => l is Lobby);
                        ((Lobby)existingLobby).ExtendSegments(); 
                        
                    }
                    return true;  

                case StructureTypes.Office: 
                    var office = GetRoom(structure, startX, floorNumber);
                    floor = GetFloorOne(new Range(startX, startX + office.Segments), floorNumber);
                    ((Room)office).GetFloorNumber(floor.FloorNumber); ///ummm.... 
                    if (floor.IsLobbyFloor())
                    {
                        return false;
                    }
                    floor.AddRoom(office);
                    tower.AddFloor(floor);
                    return true;
                    
                default:
                    return false;
            }
        }

        public bool ProcessFloor(Range range, int floorNumber)
        {
            if (!FloorValidation.IsValidRangeOnMap(range, floorNumber))
            {
                Console.WriteLine("Invalid position within map.");
                return false;
            }
            var floor = GetExistingFloor(range, floorNumber);

            if(floor ==null)
            {
                if(tower.IsNextFloorNumber(floorNumber))
                {
                    floor = new Floor(range, floorNumber);
                    tower.AddFloor(floor);
                }
            }
            ///////////
            //var floor = GetFloor(range, floorNumber);

            //if (!floor.IsPreexisting)
            //{
            //    tower.AddFloor(floor);
            //}
            else
            {
                if (!FloorValidation.IsFloorPositionPreexisting(range, floor))
                {
                    Console.WriteLine("Invalid position. Must be larger than current floor position");
                    return false;
                }
                range = floor.GetExtendedFloorRange(range);
                floor.ExtendRange(range);
            }

            return true;
        }

        private bool IsPositionGivenInInput(string[] inputs)
        {
            if (inputs.Length < 3)
            {
                Console.WriteLine("Invalid input.");
                return false;
            }
            return true;
        }

        private bool IsStructureValid(StructureTypes? structure)
        {
            if (structure == null)
            {
                Console.WriteLine("Invalid structure.");
                return false;
            }
            return true;
        }

        public bool IsInputSortaValid(string[] inputs, StructureTypes? structure)
        {
            return IsPositionGivenInInput(inputs) && IsStructureValid(structure);
        }

        private void ProcessStairRequest(int floorNumber)
        {
            tower.Floors[floorNumber - 1].AddStairs(floorNumber);
            tower.Floors[floorNumber].AddStairs(floorNumber);
        }

        public IRoom GetRoom(StructureTypes? desiredRoom, int x, int floorNumber)
        {
            switch (desiredRoom)
            {
                case StructureTypes.Lobby:
                    return new Lobby(x, tower.SetFloorNumber());
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
        private Floor GetFloorOne(Range range, int floorNumber)
        {
            //var floor = tower.GetExistingFloor(floorNumber) ?? new Floor(range);
            //floor.FloorNumber = tower.SetFloorNumber();
            //return floor;

            if (!tower.IsValidExistingFloorNumber(floorNumber))
            {
                if (!tower.IsNextFloorNumber(floorNumber))
                {
                    Console.WriteLine("What the heck is this floor number?!");
                    return null;
                }
                return new Floor(range, tower.SetFloorNumber());

            }
            return tower.Floors[floorNumber - 1];

        }

        private Floor GetExistingFloor(Range range, int floorNumber)
        {
            if (!tower.IsValidExistingFloorNumber(floorNumber))
            {
                return null;

            }
            return tower.Floors[floorNumber - 1];

        }
    }
}
