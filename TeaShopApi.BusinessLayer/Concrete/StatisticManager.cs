﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaShopApi.BusinessLayer.Abstract;
using TeaShopApi.DataAccessLayer.Abstract;

namespace TeaShopApi.BusinessLayer.Concrete
{
    public class StatisticManager : IStatisticService
    {
        private readonly IStatisticDal _statisticDal;

        public StatisticManager(IStatisticDal statisticDal)
        {
            _statisticDal = statisticDal;
        }

        public int TDrinkCount()
        {
            return _statisticDal.DrinkCount();
        }

        public decimal TDrinktAverageCount()
        {

            return _statisticDal.DrinktAverageCount();
        }

        public string TLastDrinkName()
        {
            return _statisticDal.LastDrinkName();
        }

        public string TMaxPriceDrink()
        {
            return _statisticDal.MaxPriceDrink();

        }
    }
}
