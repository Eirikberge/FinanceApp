using FinanceApp.Models.Dtos;
using FinanceApp.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Globalization;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FinanceApp.Web.Pages
{
	public class MyPortfolioBase : ComponentBase
	{


		[Inject]
		public ITradeService TradeService { get; set; }
		public IEnumerable<TradeDto> Trades { get; set; }
		[Inject]
		public ICalendarInfoService CalendarInfoService { get; set; }
		public IEnumerable<EarningsCalendarDto> EarningsCalendarEvents { get; set; }
		
		public IEnumerable<StockDto> _filteredStocks;
		protected override async Task OnInitializedAsync()
		{
			EarningsCalendarEvents = await CalendarInfoService.GetCalendarInfo();

			_filteredStocks.ToList();

		}


		//public async Task UpdateFilteredStocks(string searchString)
		//{
		//	_filteredStocks = string.IsNullOrEmpty(searchString) ? Stocks :
		//		Stocks.Where(stock =>
		//			stock.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
		//			stock.Symbol.Contains(searchString, StringComparison.OrdinalIgnoreCase));
		//}

		public double GetTotalGain()
		{
			return 123;
		}

		public double GetTotalWorth()
		{
			return 123;
		}

		public int GetWeekNumber(DateTime date)
		{
			return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
		}
	}
}