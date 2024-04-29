using FinanceApp.Models.Dtos;
using FinanceApp.Web.Models;
using FinanceApp.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace FinanceApp.Web.Pages
{
	public class StockBase : ComponentBase
	{
		[Inject]
		public IStockService StockService { get; set; }

		public IEnumerable<StockDto> Stocks { get; set; }

		protected override async Task OnInitializedAsync()
		{
			Stocks = await StockService.GetStocks();
		}

		public int GetWeekNumber(DateTime date)
		{
			return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
		}
	}
}