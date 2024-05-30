using System.Net.Http.Json;
using FinanceApp.Models.Dtos;
using FinanceApp.Web.Services.Contracts;

namespace FinanceApp.Web.Services
{
	public class BasicFinancialDataService : IBasicFinancialDataService
	{
		private readonly HttpClient _httpClient;

		public BasicFinancialDataService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<BasicFinancialsDto> GetBasicFinancialsData(string symbol)
		{
			try
			{
				var basicFinacialData = await _httpClient.GetFromJsonAsync<BasicFinancialsDto>($"https://localhost:7282/api/GetBasicFinancials/api/basicfinancials?symbol={symbol}");
				return basicFinacialData;
			}
			catch (Exception ex)
			{
				throw;
			}
		}
	}
}

