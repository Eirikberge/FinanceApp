using FinanceApp.Api.Data;
using FinanceApp.Api.Entities;
using FinanceApp.Api.Repositorys.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Api.Repositorys
{
	public class StockRepository : IStockRepository
	{
		private readonly FinanceAppContext _context;

		public StockRepository(FinanceAppContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Stock>> GetStocks()
		{
			return await _context.Stocks.ToListAsync();
		}
	}
}

