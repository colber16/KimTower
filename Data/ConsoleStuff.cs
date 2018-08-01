
namespace KimTower.Data
{
    using System;
    using System.Collections.Generic;

    public static class ConsoleStuff
    {
        const string inputRequest = "\n Enter: Structure Type | Floor Number | Starting Point | Ending Point";
        const string continueRequest = "\n Build more stuff? (y/n) OR continue (down arrow)";
        const string farewell = "\n ___Game Over___";

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

        public static void ProcessContinueInput(ref bool play, ref bool newInput)
        {
            var someMoreInput = Console.ReadKey();

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
        }

        public static void PrintContinueRequest()
        {
            FormatPrint(continueRequest);
        }
    }
}
