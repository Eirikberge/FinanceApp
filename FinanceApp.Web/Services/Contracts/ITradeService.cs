using FinanceApp.Models.Dtos;

namespace FinanceApp.Web.Services.Contracts
{
	public interface ITradeService
	{
		Task<IEnumerable<TradeDto>> GetTrades();
		Task AddTrade(TradeDto trade);
	}
}
