using System.Net.Http.Json;
using System.Text;
using FinanceApp.Models.Dtos;
using FinanceApp.Web.Services.Contracts;
using Newtonsoft.Json;

namespace FinanceApp.Web.Services
{
    public class TradeService : ITradeService
    {
	    private readonly HttpClient _httpClient;

	    public TradeService(HttpClient httpClient)
	    {
		    _httpClient = httpClient;
	    }
		public async Task<IEnumerable<TradeDto>> GetTrades()
		{
			try
			{
				var trades = await _httpClient.GetFromJsonAsync<IEnumerable<TradeDto>>("https://localhost:7282/api/trades");
				return trades;
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		public async Task AddTrade(TradeDto addTrade)
		{
			var json = JsonConvert.SerializeObject(addTrade);
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			var stringContent = await content.ReadAsStringAsync();
			Console.WriteLine(stringContent);

			await _httpClient.PostAsync("https://localhost:7282/api/Trade", content);
		}
	}
}
