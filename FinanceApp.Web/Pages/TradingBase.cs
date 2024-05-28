using FinanceApp.Models.Dtos;
using FinanceApp.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace FinanceApp.Web.Pages
{
	public class TradingBase:ComponentBase
	{


		[Inject]
		public ICompanyInfoService CompanyInfoService { get; set; }
		public IEnumerable<CompanyInfoDto> CompanyInfos { get; set; }
		[Inject]
		public ITradeService TradeService { get; set; }
		public IEnumerable<TradeDto> Trades { get; set; }
		protected override async Task OnInitializedAsync()
		{
			CompanyInfos = await CompanyInfoService.GetCompanyInfo();
		}

		public void AddTrade(TradeDto trade)
		{
			TradeService.AddTrade(trade);
		}
	}
}
