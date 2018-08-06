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

            var structure = ConsoleStuff.GetStructureFromInput(desiredStructure);

            if(!IsInputSortaValid(inputs, structure))
            {
                return false;
            }

            int.TryParse(inputs[2], out startX);

            Range range;

            return BuildStructure(structure, startX, floorNumber, inputs);

            //if (!tower.HasLobby && !structure.Equals(StructureTypes.Lobby))
            //{
            //    Console.WriteLine("Must create lobby first");
            //    return false;
            //}
            //if (structure.Equals(StructureTypes.Floor))
            //{
            //    int.TryParse(inputs[3], out int x2);
            //    //x2 == room.segments
            //    var range = new Range(x, x2);
            //    return ProcessFloor(range, floorNumber);
            //}

            //if (structure.Equals(StructureTypes.Stairs))
            //{
            //    ProcessStairRequest(floorNumber);
            //}
            //if (structure.Equals(StructureTypes.Office)
            //   || structure.Equals(StructureTypes.Lobby))
            //{
        //        IRoom room;

        //        if (structure.Equals(StructureTypes.Lobby))
        //        {
        //            ////////*******Need to do validations first.
        //            if (!tower.HasLobby)
        //            {
        //                room = new Lobby(x, floorNumber);
        //                tower.HasLobby = true;
        //            }
        //            else
        //            {
        //                room = (Lobby)tower.Floors[0].Rooms[0];
        //            }

        //        }
        //        else
        //        {
        //            room = GetRoomType(structure,x, floorNumber);
        //        }
        //        if (!FloorValidation.IsRoomValidForFloor(room, floorNumber))
        //        {
        //            Console.WriteLine("Invalid room for floor");
        //            return false;
        //        }
        //        else
        //        {

        //            //var position = GetRoomPosition(x, room.Segments, floorNumber);
        //            var range = room.Range;

        //            if (!FloorValidation.IsValidRangeOnMap(range, floorNumber))
        //            {
        //                Console.WriteLine("Invalid position within map.");
        //                return false;
        //            }
        //            var floor = GetFloor(range, floorNumber);

        //            if (!floor.IsPreexisting)
        //            {
        //                tower.AddFloor(floor);
        //            }
        //            else
        //            {
        //                //unavailable for position
        //                if (!FloorValidation.IsFloorPositionPreexisting(range, floor))
        //                {
        //                    Console.WriteLine("Invalid position. Must be larger than current floor position");
        //                    return false;
        //                }
        //                range = floor.GetExtendedFloorRange(range);
        //                floor.ExtendPosition(range);
        //            }

        //            AddRoom(room, floor);
        //        }
           // }

            //return true;

        }

        private bool BuildStructure(StructureTypes? structure, int startX, int floorNumber, string[] inputs)
        {
            switch (structure)
            {
                case StructureTypes.Floor:
                    int.TryParse(inputs[3], out int endX);
                    return ProcessFloor(new Range(startX, endX), floorNumber);

                case StructureTypes.Lobby:
                    var lobby = GetRoom(structure, startX, floorNumber);
                    var floor = GetFloor(new Range(startX, startX + lobby.Segments), floorNumber);
                    tower.AddFloor(floor);
                    if(!floor.IsLobbyFloor())
                    {
                        return false;
                    }
                    if(!floor.HasLobby())
                    {
                        floor.AddRoom(lobby);
                    }
                    else
                    {
                        var existingLobby = floor.Rooms.SingleOrDefault(l => l is Lobby);
                        ((Lobby)existingLobby).ExtendSegments(); 
                        
                    }
                   

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
            var floor = GetFloor(range, floorNumber);

            if (!floor.IsPreexisting)
            {
                tower.AddFloor(floor);
            }
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
                    //tower.HasLobby = true;
                }
            }
            else
            {
                floor.Rooms.Add(room);
            }
        }

        private IRoom GetRoom(StructureTypes? desiredRoom, int x, int floorNumber)
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
        private Floor GetFloor(Range range, int floorNumber)
        {
            var floor = tower.GetExistingFloor(floorNumber) ?? new Floor(range, floorNumber);
            return floor;
        }


    }
}
