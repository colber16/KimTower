
namespace KimTower.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class ConsoleStuff
    {
        const string inputRequest = "\n Enter: Structure Type | Floor Number | Starting Point | Ending Point";
        const string continueRequest = "\n Build more stuff? (y/n) OR continue (down arrow)";
        const string farewell = "\n ___Game Over___";
        //readonly string lobby = ((StructureTypes)'l').ToString();
    

        public static void PrintInputRequest()
        {
            FormatPrint(inputRequest);
        }

        private static void FormatPrint(string input)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(input);
            Console.ResetColor();
        }

        public static void PrintTitle()
        {
            Console.BackgroundColor = ConsoleColor.Black;

            var colors = new List<ConsoleColor> { ConsoleColor.Red, ConsoleColor.Blue, ConsoleColor.Green };

            foreach (var color in colors)
            {
                Console.ForegroundColor = color;
                Console.Write("KimTower".PadRight(18));
                Console.Write("KimTower".PadRight(18));
                Console.Write("KimTower".PadRight(18));
                Console.Write("KimTower".PadRight(18));
                Console.WriteLine("KimTower");
            }
        }
        //public static bool IsValidStructureInput(string input)
        //{
        //    var structureTypes = new List<string>();

        //    foreach(var structure in (StructureTypes[])Enum.GetValues(typeof(StructureTypes)))
        //    {
        //        structureTypes.Add(structure.ToString()); Enum.
        //    }
        //    return structureTypes.Contains(input);
        //}
        public static StructureTypes? GetStructure(char input)
        {
            if(Enum.IsDefined(typeof(StructureTypes), (int)input))
            {
               return (StructureTypes)input; 
            }
            return null;
            //return (StructureTypes) Enum.ToObject(typeof(StructureTypes), input[0]);
        }

        public static void ProcessContinueInput(ref bool play, ref bool newInput)
        {
            var validInput = false;

            while(!validInput)
            {
                var someMoreInput = Console.ReadKey();

                if(someMoreInput != null)
                {
                    if (someMoreInput.Key == ConsoleKey.Y)
                    {
                        play = true;
                        newInput = true;
                    }

                    if (someMoreInput.Key == ConsoleKey.N)
                    {
                        play = false;
                        FormatPrint(farewell);
                    }

                    if (someMoreInput.Key == ConsoleKey.DownArrow)
                    {
                        newInput = false;
                    }

                    validInput = true;
                }
                else
                {
                    Console.WriteLine("\n Invalid Input");
                }
            }
         
        }

        public static void PrintContinueRequest()
        {
            FormatPrint(continueRequest);
        }

        public static bool IsFloorRequest(string[] inputs)
        {
            return inputs.Contains("f");
        }

        public static bool IsStairRequest(string[] inputs)
        {
            return inputs.Contains("s");
        }
        public static void PrintGameStats(Tower tower, Time time)
        {
            for (int i = 0; i < tower.Floors.Count; i++)
            {
                Console.WriteLine($"Floor Number:{tower.Floors[i].FloorNumber}, Segments: {tower.Floors[i].Segments}, Rooms Count: {tower.Floors[i].Rooms.Count}");

            }
            Console.WriteLine(time.ToString());
            Console.WriteLine($"Money: {tower.Ledger.TotalProfit}");
        }
    }
    public enum StructureTypes
    {
        Lobby = 'l',
        Office = 'o',
        Stairs = 's',
        Restaurant = 'r',
        Condo = 'c',
        Elevator = 'e'
    }
}
