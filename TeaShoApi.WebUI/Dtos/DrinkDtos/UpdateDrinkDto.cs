﻿namespace TeaShopApi.WebUI.Dtos.DrinkDtos
{
    public class UpdateDrinkDto
    {
        public int drinkID { get; set; }
        public string drinkName { get; set; }
        public decimal drinkPrice { get; set; }
        public string drinkImageUrl { get; set; }

    }
}
