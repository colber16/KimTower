﻿
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
            ConsoleStuff.PrintGameStats(tower, time);
        }

        private void Update()
        {
            this.time = time.RunTime();

            tower.CollectRent(time);
        }

        //private Floor FloorCheck(Position position)
        //{
        //    foreach (var floor in tower.Floors)
        //    {
        //        if (floor.FloorNumber == position.FloorNumber)
        //        {
        //            floor.ExtendSegments(position.);
        //            return floor;

        //        }
        //    }
        //    return GetNewFloor(position);

        //}

        private Floor GetNewFloor(Position position)
        {
            var newFloor = new Floor(position);

            tower.Floors.Add(newFloor);

            return newFloor;
        }

        private bool ProcessInput(string input)
        {
            var inputs = input.Split(" ");
            var desiredStructure = Convert.ToChar(inputs[0]);
            int floorNumber;
            int x;
            //Floor floor;

            var structure = ConsoleStuff.GetStructureFromInput(desiredStructure);

            if (structure == null)
            {
                Console.WriteLine("Invalid structure.");
                return false;
            }

            int.TryParse(inputs[1], out floorNumber);

            if (!IsPositionGivenInInput(inputs))
            {
                return false;
            }

            int.TryParse(inputs[2], out x);

            if (structure.Equals(StructureTypes.Floor))
            {
                int.TryParse(inputs[3], out int x2);
                //x2 == room.segments
                //can not have a position without a floor
                var position = new Position(x, x2, floorNumber);

                if (!FloorValidation.IsValidPositionOnMap(position))
                {
                    Console.WriteLine("Invalid position within map.");
                    return false;
                }
                var floor = GetFloor(position);

                if(floor.Preexisting)
                {
                    if (!FloorValidation.IsValidPositionInExistingFloor(x, x2, floor))
                    {
                        Console.WriteLine("Invalid position.");
                        return false;
                    }
                    position = floor.GetNewFloorPosition(x, x2);
                }
                //move to preexisting
                //var floorPosition = floor.GetNewFloorPosition(x, x2);

                floor.ExtendPosition(position);

                if(!floor.Preexisting)
                {
                    tower.AddFloor(floor);
                }
                return true;

                //if (!FloorValidation.IsValidPositionOnMap(x, x2, floorNumber))
                //{
                //    Console.WriteLine("Invalid position.");
                //    return false;
                //}

                //floor = tower.GetExistingFloor(floorNumber);

                //if (floor == null)
                //{
                //    return CreateAndAddNewFloor(floorNumber, x, x2);
                //}
                //if (!FloorValidation.IsValidPositionInExistingFloor(x, x2, floor))
                //{
                //    Console.WriteLine("Invalid position.");
                //    return false;
                //}

                //var position = floor.GetNewFloorPosition(x, x2);
                //floor.ExtendPosition(position);
                //return true;

            }

            if (structure.Equals(StructureTypes.Stairs))
            {
                ProcessStairRequest(floorNumber);
            }
            if (structure.Equals(StructureTypes.Office)
               || structure.Equals(StructureTypes.Lobby))
            {
                IRoom room;

                if (structure.Equals(StructureTypes.Lobby) && tower.Floors.Count != 0 && tower.Floors[0].Rooms.Count != 0)
                {
                    room = (Lobby)tower.Floors[0].Rooms[0];
                    //maybe return null and then check and then extend and then and then and then.
                }
                else
                {
                    room = GetRoomType(structure);
                }
                if (!FloorValidation.IsRoomValidForFloor(room, floorNumber))
                {
                    Console.WriteLine("Invalid room for floor");
                    return false;
                }
                else
                {
                    //Do something about this
                    //floor = FloorCheck(x, room.Segments, floorNumber);

                    //AddRoom(room, floor);
                }
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

        //private bool CreateAndAddNewFloor(int floorNumber, int x, int x2)
        //{
        //    var newFloor = new Floor(x, x2, floorNumber);

        //    tower.Floors.Add(newFloor);

        //    return true;
        //}

        private void ProcessStairRequest(int floorNumber)
        {
            var bottomFloor = tower.Floors.SingleOrDefault(f => f.FloorNumber == floorNumber);
            bottomFloor.Stairs.Add(new StairCase(floorNumber));

            var topFloor = tower.Floors.SingleOrDefault(f => f.FloorNumber == bottomFloor.FloorNumber + 1);
            topFloor.Stairs.Add(new StairCase(bottomFloor.FloorNumber));
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
                }
            }
            else
            {
                floor.Rooms.Add(room);
            }
        }

        private IRoom GetRoomType(StructureTypes? desiredRoom)
        {
            switch (desiredRoom)
            {
                case StructureTypes.Lobby:
                    return new Lobby();
                case StructureTypes.Office:
                    return new Office();
                //case StructureTypes.Condo:
                //return new Condo();
                //case StructureTypes.Restaurant:
                //return new Restaurant();

                default:
                    return null;
            }

        }
        private Floor GetFloor(Position position)
        {
            var floor = tower.GetExistingFloor(position.FloorNumber) ?? new Floor(position);
            return floor;
        }
        
        //private static Position GetFloorPosition()
        //{
        //    var position = floor.GetNewFloorPosition(x, x2);
        //    floor.ExtendPosition(position);
        //    return true;
        //}
    }
}
