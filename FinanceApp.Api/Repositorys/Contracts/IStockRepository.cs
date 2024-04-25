using FinanceApp.Api.Entities;

namespace FinanceApp.Api.Repositorys.Contracts
{
	public interface IStockRepository
	{
		Task<IEnumerable<Stock>> GetStocks();
		Task AddStock(Stock stock);
	}
}
