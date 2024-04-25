using FinanceApp.Api.Data;
using FinanceApp.Api.Entities;
using FinanceApp.Api.Repositorys.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Api.Controllers
{
	[ApiController]
	[Route("api/stocks")]
	public class StockController : Controller
	{
		private readonly IStockRepository _stockRepository;
		private readonly FinanceAppContext _context;

		public StockController(IStockRepository stockRepository, FinanceAppContext context)
		{
			_stockRepository = stockRepository;
			_context = context;
		}

		[HttpGet]
		public async Task<IActionResult> GetStocks()
		{
			try
			{
				var stocks = await _stockRepository.GetStocks();
				return Ok(stocks);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost]
		public async Task<IActionResult> AddStock([FromBody] Stock stock)
		{
			try
			{
				await _stockRepository.AddStock(stock);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("{symbol}/{newQty}")]
		public IActionResult UpdateStock(string symbol, int newQty)
		{
			var stock = _context.Stocks.FirstOrDefault(s => s.Symbol == symbol);

			if (stock == null)
			{
				return NotFound();
			}

			stock.Qty = newQty;

			try
			{
				_context.SaveChanges();
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
