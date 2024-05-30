using System.Net.Http.Json;
using FinanceApp.Models.Dtos;
using FinanceApp.Web.Services.Contracts;

namespace FinanceApp.Web.Services
{
	public class StockPriceCandleService : IStockPriceCandleService
	{
		private readonly HttpClient _httpClient;

		public StockPriceCandleService(HttpClient httpClient) 
		{
			_httpClient = httpClient;
		}

		public async Task<StockPriceCandleDto> GetStockPriceCandle(string symbol)
		{
			try
			{
				var stockPriceCandle = await _httpClient.GetFromJsonAsync<StockPriceCandleDto>($"https://localhost:7282/api/GetStockPrice/api/getstockprice/{symbol}");
				return stockPriceCandle;
			}
			catch (Exception ex)
			{
				throw;
			}
		}
	}
}