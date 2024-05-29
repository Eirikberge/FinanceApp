using FinanceApp.Models.Dtos;

namespace FinanceApp.Web.Services.Contracts
{
	public interface IStockHoldingService
	{
		Task<IEnumerable<StockHoldingDto>>GetStockHoldingById(int id);
	}
}
