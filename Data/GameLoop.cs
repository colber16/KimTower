
namespace KimTower.Data
{
    using System;
    using System.Linq;

    public class GameLoop
    {
        public void Run(Tower tower)
        {
            Build build = new Build();

            while (true)
            {
                var input = Console.ReadLine();
                ProcessInput(input, tower);
                // Update();
                Render(tower);

            }
        }

        private void Render(Tower tower)
        {
            for (int i = 0; i < tower.Floors.Count; i++)
            {
                Console.WriteLine($"Floors:{tower.Floors[i].FloorNumber}, Segments: {tower.Floors[i].Segments}, Rooms Count: {tower.Floors[i].Rooms.Count}");

            }
        }

        private void Update()
        {
            throw new NotImplementedException();
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

            //if (room is Lobby)
            //{
            //    if (floor.Rooms.Any(l => l is Lobby))
            //    {
            //        ((Lobby)room).ExtendSegments();
            //    }
            //}
            //else
            //{
            //    floor.Rooms.Add(room);

            //}
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
