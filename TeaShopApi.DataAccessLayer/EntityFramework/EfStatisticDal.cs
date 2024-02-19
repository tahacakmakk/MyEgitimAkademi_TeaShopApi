using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaShopApi.DataAccessLayer.Abstract;
using TeaShopApi.DataAccessLayer.Context;

namespace TeaShopApi.DataAccessLayer.EntityFramework
{
    public class EfStatisticDal : IStatisticDal
    {
        private readonly TeaContext _teaContext;

        public EfStatisticDal(TeaContext teaContext)
        {
            _teaContext = teaContext;
        }

        public int DrinkCount()
        {
            int value = _teaContext.Drinks.Count();
            return value;
        }

        public decimal DrinktAverageCount()
        {
            decimal value = _teaContext.Drinks.Average(x => x.DrinkPrice);
            return value;
        }

        public string LastDrinkName()
        {
            string value = _teaContext.Drinks.OrderByDescending(x => x.DrinkID).Select(z => z.DrinkName).Take(1).FirstOrDefault();
            return value;
        }

        public string MaxPriceDrink()   
        {
            decimal price = _teaContext.Drinks.Max(x => x.DrinkPrice);
            string value = _teaContext.Drinks.Where(x=>x.DrinkPrice == price).Select(z=>z.DrinkName).FirstOrDefault();
            return value;
        }
    }
}
