using System.Text.Json;
using FinanceApp.Api.Entities;
using FinanceApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace FinanceApp.Controllers
{
    [ApiController]
	[Route("[controller]")]
	public class GetStockPriceController : Controller
	{
		private readonly HttpClient _httpClient;

		public GetStockPriceController(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
	
		[HttpGet("api/getstockprice/{symbol}")] // decorator

		public ActionResult<StockPriceCandle> GetStockPrice(string symbol)
		{
			var request = new HttpRequestMessage(HttpMethod.Get, $"https://finnhub.io/api/v1/quote?symbol={symbol}");
			request.Headers.Add("X-Finnhub-Token", "co5tdu1r01qv77g7q8bgco5tdu1r01qv77g7q8c0");
			var response = _httpClient.Send(request);
			if (!response.IsSuccessStatusCode)
			{
				return null;
			}

			var deserialized = JsonSerializer.Deserialize<QuoteResponse>(response.Content.ReadAsStream()); // må legge inn en håndtering av feil
			if (deserialized == null)
			{
				return null;
			}

			var stockPrice = new StockPriceCandle();
			stockPrice.Symbol = symbol;
			stockPrice.Current = deserialized.Current;
			stockPrice.High = deserialized.High;
			stockPrice.Low = deserialized.Low;
			stockPrice.Previous = deserialized.Previous;
			stockPrice.PercentChange = deserialized.PercentChange;
			stockPrice.Change = deserialized.Change;
			stockPrice.Open = deserialized.Open;
			stockPrice.Time = DateTime.Now;

			return stockPrice;
		}
	}
}