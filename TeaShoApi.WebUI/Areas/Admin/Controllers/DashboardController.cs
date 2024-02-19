using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TeaShopApi.WebUI.Dtos.DrinkDtos;

namespace TeaShopApi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class DashboardController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7015/api/Statistic/GetDrinktAverageCount");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.v = jsonData;


            var responseMessage2 = await client.GetAsync("https://localhost:7015/api/Statistic/GetDrinkCount");
            var jsonData2 = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.v2 = jsonData2;

            var responseMessage3 = await client.GetAsync("https://localhost:7015/api/Statistic/GetLastDrinkName");
            var jsonData3 = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.v3 = jsonData3;

            var responseMessage4 = await client.GetAsync("https://localhost:7015/api/Statistic/GetMaxPriceDrink");
            var jsonData4 = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.v4 = jsonData4;

            return View();


        }

    }
}
