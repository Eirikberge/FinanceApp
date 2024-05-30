using FinanceApp.Models.Dtos;

namespace FinanceApp.Web.Services.Contracts
{
	public interface IStockPriceCandleService
	{
		Task<StockPriceCandleDto> GetStockPriceCandle(string symbol);
	}
}
