
namespace KimTower.Data
{
    using System;

    public class Rating
    {
        const int twoStarPopulation = 300;
        const int threeStarPopulation = 1000;
        const int fourStarPopulation = 5000;
        const int fiveStarPopulation = 10000;

        public Stars Stars { get; set; }

        public Rating()
        {
            this.Stars = Stars.One;
        }

        //properties ratings
        //calculate each rating
        //what qualifies for rating

        public bool IsTwoStar(Tower tower)
        {
            return (tower.Population >= twoStarPopulation);
        }

        public bool IsThreeStar(Tower tower)
        {
            //this is wrong
            //foreach(var floor in tower.Floors)
            //{
            //    foreach (var room in floor.Rooms)
            //    {
            //        if(room == StructureTypes.SecurityStation)
            //        {
            //            continue;
            //        }
            //    }
            //}
            return (tower.Population >= threeStarPopulation);
                   
        }
        public bool IsFourStar(Tower tower)
        {
            //Maybe move to tower
            //recycling center, medical center, 2 suties, vip favorable rating
            return (tower.Population >= fourStarPopulation);

        }
        public bool IsFiveStar(Tower tower)
        {
            
            //metro
            return (tower.Population >= fiveStarPopulation);

        }
        public bool IsTower(Tower tower)
        {
            //is cathedral on top floor
            throw new NotImplementedException();

        }

    }
    public enum Stars
    {
        One,
        Two,
        Three,
        Four,
        Five,
        Tower

    }
}
