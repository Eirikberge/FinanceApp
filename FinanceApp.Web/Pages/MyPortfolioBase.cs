using FinanceApp.Models.Dtos;
using FinanceApp.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace FinanceApp.Web.Pages
{
	public class MyPortfolioBase : ComponentBase
	{
		[Inject]
		public IStockService StockService { get; set; }
		public IEnumerable<StockDto> Stocks { get; set; }

		protected override async Task OnInitializedAsync()
		{
			Stocks = await StockService.GetStocks();
		}
	}
}