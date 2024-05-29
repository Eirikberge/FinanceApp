using FinanceApp.Models.Dtos;
using FinanceApp.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace FinanceApp.Web.Pages
{
	public class CalendarBase : ComponentBase
	{

		[Inject]
		public IEarningsCalendarDataService CalendarInfoService { get; set; }
		public IEnumerable<EarningsCalendarDto> EarningsCalendarList { get; set; }
		[Inject]
		public IStockHoldingService StockHoldingService { get; set; }
		public IEnumerable<StockHoldingDto> StockHoldings { get; set; }

		protected override async Task OnInitializedAsync()
		{
			EarningsCalendarList = await CalendarInfoService.GetCalendarInfo();
			StockHoldings = await StockHoldingService.GetStockHoldingById(1);
		}
		public static string GetMonthAsString()
		{
			int targetMonth = (DateTime.Now.Month - 1) % 12 + 1;

			string currentMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(targetMonth); var capitalizedMonth = currentMonth.Substring(0, 1).ToUpper() + currentMonth.Substring(1);
			return capitalizedMonth;
		}
	}
}
