using FinanceApp.Models.Dtos;
using System.Net.Http.Json;
using FinanceApp.Web.Services.Contracts;
using Newtonsoft.Json;
using System.Text;

namespace FinanceApp.Web.Services
{
	public class StockService : IStockService
	{
		private readonly HttpClient _httpClient;

		public StockService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<IEnumerable<StockDto>> GetStocks()
		{
			try
			{
				var stocks = await _httpClient.GetFromJsonAsync<IEnumerable<StockDto>>("https://localhost:7282/api/stocks");
				return stocks;
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		public async Task AddStock(StockDto addModel)
		{
			var json = JsonConvert.SerializeObject(addModel);
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			await _httpClient.PostAsync("https://localhost:7282/api/stocks", content);
		}

		public async Task UpdateStock(StockDto updateModel)
		{
			var json = JsonConvert.SerializeObject(updateModel);
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			await _httpClient.PutAsync($"https://localhost:7282/api/stocks/{updateModel.Symbol}/{updateModel.Qty}", content);
		}
	}
}