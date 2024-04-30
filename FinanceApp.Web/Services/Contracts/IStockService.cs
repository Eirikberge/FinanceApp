using FinanceApp.Models.Dtos;

namespace FinanceApp.Web.Services.Contracts
{
	public interface IStockService
	{
		Task<IEnumerable<StockDto>> GetStocks();
		Task AddStock(StockDto stock);
		Task UpdateStock(StockDto stock);
	}
}
