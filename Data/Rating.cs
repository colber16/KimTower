
namespace KimTower.Data
{
    using System;

    public class Rating
    {
        const int twoStarPopulation = 300;
        const int threeStarPopulation = 1000;
        const int fourStarPopulation = 5000;
        const int fiveStarPopulation = 10000;

        public bool OneStar { get; private set; }
        public bool TwoStar { get; private set; }
        public bool ThreeStar { get; private set; }
        public bool FourStar { get; private set; }
        public bool FiveStar { get; private set; }
        public bool Tower { get; private set; }

        public Rating()
        {
            this.OneStar = true;
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
}
