using FinanceApp.Models.Dtos;
using FinanceApp.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;
using System.Globalization;


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
		[Inject]
		public IBasicFinancialDataService BasicFinancialDataService { get; set; }
		[Inject]
		public IStockPriceCandleService StockPriceCandleService { get; set; }

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
				Quantity = stock.Quantity,
			}).ToList();

			foreach (var stock in StockList)
			{
				var companyInfo = CompanyInfoList.FirstOrDefault(ci => ci.Ticker == stock.Symbol);
				if (companyInfo != null)
				{
					stock.Name = companyInfo.Name;
				}

				await StockPriceCandleService.GetStockPriceCandle(stock.Symbol);
			}

			StockList.ToList();

			GetCurrentStockBeta();
		}
		public async Task GetCurrentStockPrice()
		{
			foreach (var stock in StockList)
			{
				var response = await StockPriceCandleService.GetStockPriceCandle(stock.Symbol);

				stock.CurrentPrice = response.Current;
			}
		}

		public async Task UpdateFilteredStocks(string searchString)
		{
			StockList = string.IsNullOrEmpty(searchString) ? StockList :
				StockList.Where(stock =>
					stock.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
					stock.Symbol.Contains(searchString, StringComparison.OrdinalIgnoreCase));
		}

		private async Task GetCurrentStockBeta()
		{
			foreach (var stock in StockList)
			{
				var response = await BasicFinancialDataService.GetBasicFinancialsData(stock.Symbol);

				{
					stock.Beta = response.Beta;
					stock.DividendPSAnnual = response.DividendPerShareAnnual;
				}
			}
		}


		public double GetTotalValue(string returntype)
		{
			var totalGain = 0.00;
			var totalWorth = 0.00;

			foreach (var stock in StockList)
			{
				totalGain += (stock.CurrentPrice - stock.BuyingPrice) * stock.Quantity;
				totalWorth += stock.CurrentPrice * stock.Quantity;
			}

			if (returntype == "Gain")
			{
				return totalGain;
			}
			if (returntype == "Worth")
			{
				return totalGain;
			}

			return 0;
		}

		public int GetWeekNumber(DateTime date)
		{
			return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
		}
	}
}