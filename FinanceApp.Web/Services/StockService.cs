using FinanceApp.Models.Dtos;
using static System.Net.WebRequestMethods;
using System.Net.Http.Json;
using FinanceApp.Web.Services.Contracts;

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
	}
}