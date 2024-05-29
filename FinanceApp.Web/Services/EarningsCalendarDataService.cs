using FinanceApp.Models.Dtos;
using FinanceApp.Web.Services.Contracts;
using System.Net.Http.Json;

namespace FinanceApp.Web.Services
{
	public class EarningsCalendarDataService : IEarningsCalendarDataService
	{
		private readonly HttpClient _httpClient;

		public EarningsCalendarDataService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<IEnumerable<EarningsCalendarDto>> GetCalendarInfo()
		{
			var from = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
			var to = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1);
			try
			{
				var calendarInfo = await _httpClient.GetFromJsonAsync<IEnumerable<EarningsCalendarDto>>($"https://localhost:7282/api/GetEarningsCalendar/api/earningscalendar?from={from:yyyy-MM-dd}&to={to:yyyy-MM-dd}");
				return calendarInfo;
			}
			catch (Exception ex)
			{
				throw;
			}
		}
	}
}
