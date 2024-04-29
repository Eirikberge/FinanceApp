using FinanceApp.Models.Dtos;
using FinanceApp.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace FinanceApp.Web.Pages
{
	public class TradingBase:ComponentBase
	{
		[Inject]
		public IStockService StockService { get; set; }
		public IEnumerable<StockDto> Stocks { get; set; }

		[Inject]
		public ICompanyInfoService CompanyInfoService { get; set; }
		public IEnumerable<CompanyInfoDto> CompanyInfos { get; set; }
		protected override async Task OnInitializedAsync()
		{
			Stocks = await StockService.GetStocks();
			CompanyInfos = await CompanyInfoService.GetCompanyInfo();
		}
	}
}
