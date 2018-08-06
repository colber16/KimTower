
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
            int x;

            var structure = ConsoleStuff.GetStructureFromInput(desiredStructure);

            if (structure == null)
            {
                Console.WriteLine("Invalid structure.");
                return false;
            }
            //blow up if valid structure is passed
            int.TryParse(inputs[1], out floorNumber);

            if (!IsPositionGivenInInput(inputs))
            {
                return false;
            }

            int.TryParse(inputs[2], out x);

            //if (!tower.HasLobby && !structure.Equals(StructureTypes.Lobby))
            //{
            //    Console.WriteLine("Must create lobby first");
            //    return false;
            //}
            if (structure.Equals(StructureTypes.Floor))
            {
                int.TryParse(inputs[3], out int x2);
                //x2 == room.segments
                var range = new Range(x, x2);
                return ProcessFloor(range, floorNumber);
            }

            if (structure.Equals(StructureTypes.Stairs))
            {
                ProcessStairRequest(floorNumber);
            }
            if (structure.Equals(StructureTypes.Office)
               || structure.Equals(StructureTypes.Lobby))
            {
                IRoom room;

                if (structure.Equals(StructureTypes.Lobby))
                {
                    ////////*******Need to do validations first.
                    if (!tower.HasLobby)
                    {
                        room = new Lobby(x, floorNumber);
                        tower.HasLobby = true;
                    }
                    else
                    {
                        room = (Lobby)tower.Floors[0].Rooms[0];
                    }

                }
                else
                {
                    room = GetRoomType(structure,x, floorNumber);
                }
                if (!FloorValidation.IsRoomValidForFloor(room, floorNumber))
                {
                    Console.WriteLine("Invalid room for floor");
                    return false;
                }
                else
                {

                    //var position = GetRoomPosition(x, room.Segments, floorNumber);
                    var position = room.Position;

                    if (!FloorValidation.IsValidPositionOnMap(position))
                    {
                        Console.WriteLine("Invalid position within map.");
                        return false;
                    }
                    var floor = GetFloor(position);

                    if (!floor.IsPreexisting)
                    {
                        tower.AddFloor(floor);
                    }
                    else
                    {
                        //unavailable for position
                        if (!FloorValidation.IsFloorPositionPreexisting(position, floor))
                        {
                            Console.WriteLine("Invalid position. Must be larger than current floor position");
                            return false;
                        }
                        position = floor.GetExtendedFloorPosition(position);
                        floor.ExtendPosition(position);
                    }

                    AddRoom(room, floor);
                }
            }

            return true;

        }

        public bool ProcessFloor(Range range, int floorNumber)
        {

            if (!FloorValidation.IsValidPositionOnMap(range, floorNumber))
            {
                Console.WriteLine("Invalid position within map.");
                return false;
            }
            var floor = GetFloor(position);

            if (!floor.IsPreexisting)
            {
                tower.AddFloor(floor);
            }
            else
            {
                if (!FloorValidation.IsFloorPositionPreexisting(position, floor))
                {
                    Console.WriteLine("Invalid position. Must be larger than current floor position");
                    return false;
                }
                position = floor.GetExtendedFloorPosition(position);
                floor.ExtendPosition(position);
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

        private void ProcessStairRequest(int floorNumber)
        {
            tower.Floors[floorNumber - 1].AddStairs(floorNumber);
            tower.Floors[floorNumber].AddStairs(floorNumber);
        }

        private void AddRoom(IRoom room, Floor floor)
        {
            if (room is Lobby)
            {
                if ((floor.Rooms.Any(l => l is Lobby)))
                {
                    ((Lobby)room).ExtendSegments();
                }
                else
                {
                    floor.Rooms.Add(room);
                    tower.HasLobby = true;
                }
            }
            else
            {
                floor.Rooms.Add(room);
            }
        }

        private IRoom GetRoomType(StructureTypes? desiredRoom, int x, int floorNumber)
        {
            switch (desiredRoom)
            {
                case StructureTypes.Lobby:
                    return new Lobby(x, floorNumber);
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
        private Floor GetFloor(Position position)
        {
            var floor = tower.GetExistingFloor(position.FloorNumber) ?? new Floor(position);
            return floor;
        }

    }
}
