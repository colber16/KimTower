
namespace KimTower.Data
{
    using System;
    using KimTower.Data.Floors;

    public class GameLoop
    {
        Builder builder = new Builder();
        Time time = new Time(0);
        public Tower tower = new Tower();
        public GlobalProperties GlobalProperties { get; }

        public GameLoop()
        {
            this.GlobalProperties = new GlobalProperties();
        }

        public void Run()
        {
              
            ConsoleStuff.PrintTitle();

            ConsoleStuff.FormatAndPrint(ConsoleStuff.structureList);

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
            ConsoleStuff.PrintGameStats(tower, time, this.GlobalProperties);
        }

        private void Update()
        {
            this.time = time.RunTime();

            tower.CollectRent(time);
            tower.UpdateLedgerByFloor();
            this.GlobalProperties.AddIncome(tower.Ledger.TotalProfit);


        }

        public bool ProcessInput(string input)
        {
            var inputs = input.Split(" ");
            var desiredStructure = Convert.ToChar(inputs[0]);
            int floorNumber;
            int startX;
            //general input
            if (!ConsoleInputValidation.IsValidInputLength(inputs))
            {
                Console.WriteLine("Not enough input");
                return false;
            }

            //0th input
            var nullableStructure = ConsoleStuff.GetStructureFromInput(desiredStructure);

            if (nullableStructure == null)
            {
                Console.WriteLine("Invalid Structure.");
                return false;
            }
            var structure = (StructureTypes)nullableStructure;

            if (!tower.IsLobbyBuilt())
            {
                if (!(structure is StructureTypes.Lobby))
                {
                    Console.WriteLine("Must Build Lobby first");
                    return false;
                }
            }
            //1st input
            int.TryParse(inputs[1], out floorNumber);

            if (!FloorValidation.IsValidFloorForMap(floorNumber))
            {
                Console.WriteLine("Floor is too large or small.");
                return false;
            }
            if (FloorValidation.IsLobbyFloor(floorNumber))
            {
                if (!(structure is StructureTypes.Lobby))
                {
                    if (!(structure is StructureTypes.StairCase))
                    {
                        Console.WriteLine("Lobby must be on first floor.");
                        return false;
                    }
                }
            }
            var isExistingFloor = tower.IsValidExistingFloorNumber(floorNumber);

            if (!isExistingFloor)
            {
                if (!tower.IsNextFloorNumber(floorNumber))
                {
                    Console.WriteLine("Floor does not existing and preceding floor has not be created.");
                    return false;
                }
            }
            //2nd input
            int.TryParse(inputs[2], out startX);
            //3rd input if any
            var endX = GetEndX(inputs, startX, structure);
            var range = new Range(startX, endX);
            //validate range
            if (!(FloorValidation.IsValidRangeOnMap(range)))
            {
                Console.WriteLine("Invalid range on map.");
                return false;
            }
            //range exists on parent floor

            if (structure != StructureTypes.StairCase)
            {
                if (isExistingFloor && FloorValidation.IsFloorRangePreexisting(range, tower.Floors[floorNumber]))
                {
                    Console.WriteLine("Invalid range. Must be larger than current floor range");
                    return false;
                }
                if (structure != StructureTypes.Lobby && FloorValidation.IsRangeExistingOnParent(range, tower.Floors[floorNumber - 1].Range))
                {
                    Console.WriteLine("Invalid range. Bottom floor does not have this range.");
                    return false;
                }

            }
            else
            {
                if (!tower.IsValidExistingFloorNumber(floorNumber) || !tower.IsValidExistingFloorNumber(floorNumber + 1))
                {
                    Console.WriteLine("Top or Bottom floor does not exist.");
                    return false;
                }
            }

            if(!PayForStructure(structure, isExistingFloor, floorNumber, range))
            {
                Console.WriteLine("Insuffient Funds.");
                return false;
            }

            //Make Stuff
            if (!builder.BuildStuff(floorNumber, range, structure, isExistingFloor, tower))
            {
                Console.WriteLine("Something has gone terribily wrong.");
                return false;
            }
            //globalProperties.SubtractConstructionCosts(structure);
            return true;

        }

        public bool PayForStructure(StructureTypes structure, bool isExistingFloor, int floorNumber, Range range)
        {
            var cost = DetermineCost(structure, isExistingFloor, floorNumber, range);
            var sufficientBalance = IsBalanceSufficient(cost);

            if(!sufficientBalance)
            {
                return false;
            }
            this.GlobalProperties.SubtractConstructionCosts(cost);

            return true;
        }

        private bool IsBalanceSufficient(int cost)
        {
            return this.GlobalProperties.Money - cost > 0;
        }

        private int DetermineCost(StructureTypes structure, bool isExistingFloor, int floorNumber, Range range)
        {
            var cost = 0;

            if(structure != StructureTypes.Floor && structure != StructureTypes.Lobby)
            {
               cost += GetNonFloorCost(structure);

                if (!isExistingFloor)
                {
                    cost += GetFloorCost(StructureTypes.Floor, floorNumber, range, false);
                }
            }
            else
            {
                cost += GetFloorCost(structure, floorNumber, range, isExistingFloor);
            }
            return cost;
        }

        private int GetNonFloorCost(StructureTypes structure)
        {
            return StructureInfo.AllTheInfo[structure].ConstructionCost;

        }
        private int GetFloorCost(StructureTypes structure, int floorNumber, Range range, bool isExistingFloor)
        {
            int segments;

            if (isExistingFloor)
            {
                var floor = tower.Floors[floorNumber];
                var oldRange = tower.Floors[floorNumber].Range;
                var newRange = floor.GetExtendedFloorRange(range);
                var unpaidRange = newRange - oldRange;

                //need to charge for range + segments in between new range and old range.
                segments = StructureInfo.GetUnpaidSegments(unpaidRange, structure);

            }
            else
            {
                segments = StructureInfo.GetUnpaidSegments(range, structure);
            }
           

            return segments * StructureInfo.AllTheInfo[structure].ConstructionCost;
        }

        private int GetEndX(string[] inputs, int startX, StructureTypes structure)
        {
            int endX;
            if (inputs.Length > 3 && structure.Equals(StructureTypes.Floor))
            {
                int.TryParse(inputs[3], out endX);
            }
            else
            {
                endX = startX + StructureInfo.AllTheInfo[structure].Segments;
            }
            return endX;
        }
      
    }
}
