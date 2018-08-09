
namespace KimTower.Data
{
    using System;

    public static class ConsoleInputValidation
    {
        public static bool IsValidInputLength(string[] inputs)
        {
            if (inputs.Length < 3)
            {
                Console.WriteLine("Invalid input.");
                return false;
            }
            return true;
        }

        //static bool IsStructureGiven(StructureTypes? structure)
        //{
        //    if (structure == null)
        //    {
        //        Console.WriteLine("Invalid structure.");
        //        return false;
        //    }
        //    return true;
        //}

        //public static bool IsInputSortaValid(string[] inputs, StructureTypes? structure)
        //{
        //    return IsRangeGivenInInput(inputs) && IsStructureGiven(structure);
        //}
    }
}
