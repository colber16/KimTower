
namespace KimTower.Data
{
    using System;

    public static class ConsoleInputValidation
    {
        public static bool IsValidInputLength(string[] inputs, int length)
        {
            if (inputs.Length < length)
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
