using FinanceApp.Models.Dtos;
using static System.Net.WebRequestMethods;
using System.Net.Http.Json;

namespace FinanceApp.Web.Services
{
	public class StockService
	{
		private readonly HttpClient _httpClient;

		public StockService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public List<StockDto> _stocks; 

		private async Task GetStocks()
		{
			var response = await _httpClient.GetAsync("https://localhost:7282/api/stocks");
			if (response.IsSuccessStatusCode)
			{
				_stocks = await response.Content.ReadFromJsonAsync<List<StockDto>>();
			}
		}

		public async Task<List<StockDto>> ReturnStockList()
		{
			await GetStocks();
			return _stocks;
		}
	}
}
