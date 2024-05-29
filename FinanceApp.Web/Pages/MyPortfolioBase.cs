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
		public IEarningsCalendarDataService CalendarInfoService { get; set; }
		public IEnumerable<EarningsCalendarDto> EarningsCalendarList { get; set; }
		[Inject]
		public IStockHoldingService StockHoldingService { get; set; }
		public IEnumerable<StockHoldingDto> StockHoldings { get; set; }		
		[Inject]
		public ICompanyInfoService CompanyInfoService { get; set; }
		public IEnumerable<CompanyInfoDto> CompanyInfoList { get; set; }

		public IEnumerable<StockDto> StockList;

		protected override async Task OnInitializedAsync()
		{
			EarningsCalendarList = await CalendarInfoService.GetCalendarInfo();

			CompanyInfoList = await CompanyInfoService.GetCompanyInfo();

			StockHoldings = await StockHoldingService.GetStockHoldingById(1);

			StockList = StockHoldings.Select(stock => new StockDto
			{
				Symbol = stock.StockSymbol,
				BuyingPrice = stock.Price,
				Quantity = stock.Quantity
			}).ToList();

			foreach (var stockDto in StockList)
			{
				var companyInfo = CompanyInfoList.FirstOrDefault(ci => ci.Ticker == stockDto.Symbol);
				if (companyInfo != null)
				{
					stockDto.Name = companyInfo.Name;
				}
			}

			StockList.ToList();
		}


		public async Task UpdateFilteredStocks(string searchString)
		{
			StockList = string.IsNullOrEmpty(searchString) ? StockList :
				StockList.Where(stock =>
					stock.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
					stock.Symbol.Contains(searchString, StringComparison.OrdinalIgnoreCase));
		}

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