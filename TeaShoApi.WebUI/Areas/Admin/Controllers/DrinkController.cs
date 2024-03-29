﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Text;
using TeaShopApi.WebUI.Dtos.DrinkDtos;

namespace TeaShoApi.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("[area]/[controller]/[action]/{id?}")]
	public class DrinkController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public DrinkController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7015/api/Drinks");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultDrinkDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpGet]
		public IActionResult CreateDrink()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateDrink(CreateDrinkDto createDrinkDto)
		{
			var client = _httpClientFactory.CreateClient(); //İstek yapabilmemiz için client değişken, 
            var jsonData = JsonConvert.SerializeObject(createDrinkDto); //Gönderdiğimiz metni json formatına döndürür
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");//Bunu contente dönüştürmemiz gerek
			//3 parametre alıyor; 1-Kaydedilicek olan veri  2-Uluslararası yazım türü , 3- Gönderdiğimiz verinin dosya format türü.
			var responseMessage = await client.PostAsync("https://localhost:7015/api/Drinks", content);// Ekleme işlemi yapıcak 
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
            return View();

		}

		public async Task<IActionResult> DeleteDrink(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync("https://localhost:7015/api/Drinks?id="+id);
			if(responseMessage.IsSuccessStatusCode) 
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> UpdateDrink(int id)
		{
			var client= _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7015/api/Drinks/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateDrinkDto>(jsonData);
				return View(values);
			}
			return View();
			
		}
		[HttpPost]
		public async Task<IActionResult>UpdateDrink(UpdateDrinkDto updateDrinkDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateDrinkDto);
			StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
			var responseMessage = await client.PutAsync("https://localhost:7015/api/Drinks", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	

	}
}
