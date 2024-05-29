using System.Collections;
using System.Net.Http.Json;
using FinanceApp.Models.Dtos;
using FinanceApp.Web.Services.Contracts;

namespace FinanceApp.Web.Services
{
	public class StockHoldingService : IStockHoldingService
	{
		private readonly HttpClient _httpClient;

		public StockHoldingService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<IEnumerable<StockHoldingDto>> GetStockHoldingById(int id)
		{
			try
			{
				var stockHoldings = await _httpClient.GetFromJsonAsync<IEnumerable<StockHoldingDto>>($"https://localhost:7282/api/StockHolding/{id}");

				return stockHoldings;
			}
			catch (Exception ex)
			{
				throw;
			}
		}
	}
}
