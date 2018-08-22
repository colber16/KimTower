
namespace KimTower.Data
{
    using System;
    using KimTower.Data.Rooms;
    using KimTower.Data.Floors;
   
    public class Builder
    {
        public bool BuildStuff(int floorNumber,Range range, StructureTypes structure, bool existingFloor, Tower tower)
        {
            if (structure is StructureTypes.Lobby || structure is StructureTypes.Floor)
            {
                return BuildFloor(range, floorNumber, structure, existingFloor, tower) != null;
            }
            if (structure is StructureTypes.StairCase)
            {
                return BuildStairs(floorNumber, tower);
            }
            return BuildRoom(structure, range, floorNumber, existingFloor, tower);
        }

        public bool BuildRoom(StructureTypes structure, Range range, int floorNumber, bool existingFloor, Tower tower)
        {
            //But, . . .only Floors can have rooms
            IFloor floor;

            var room = GetRoom(structure, range.StartX, floorNumber);
          
            floor = BuildFloor(range, floorNumber, StructureTypes.Floor, existingFloor, tower);

            ((Floor)floor).AddRoom(room);

            tower.UpdatePopulation(room.Population);
            //needs to be evaluated if stairs are created also. 
            room.SetOccupancy(tower, floorNumber);


            return true;

        }
        public IFloor BuildFloor(Range range, int floorNumber, StructureTypes structure, bool existingFloor, Tower tower)
        {
            IFloor floor;

            if (existingFloor)
            {
                floor = tower.Floors[floorNumber];
                var oldRange = tower.Floors[floorNumber].Range;
                var newRange = floor.GetExtendedFloorRange(range);
                floor.ExtendRange(newRange);
            }
            else
            {
                switch (structure)
                {
                    case StructureTypes.Floor:

                        floor = new Floor(range);
                        break;

                    case StructureTypes.Lobby:

                        floor = new Lobby(range.StartX);
                        break;

                    default:
                        floor = null;
                        break;

                }
                tower.AddFloor(floor);
            }
            return floor;
        }

        public bool BuildStairs(int floorNumber, Tower tower)
        {
            var stairCount = tower.Floors[floorNumber].Stairs.Count;

            tower.Floors[floorNumber].AddStairs(floorNumber);
            tower.Floors[floorNumber + 1].AddStairs(floorNumber);
            ////Hmmmm......
            foreach(var room in tower.Floors[floorNumber + 1].Rooms)
            {
                room.SetOccupancy(tower, floorNumber + 1);
            }

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

    }
}