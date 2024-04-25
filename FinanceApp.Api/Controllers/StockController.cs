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

		public StockController(IStockRepository stockRepository)
		{
			_stockRepository = stockRepository;
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
		public async Task<IActionResult> UpdateStock(string symbol, int newQty)
		{
			try
			{
				var success = await _stockRepository.UpdateStock(symbol, newQty);

				if (success)
				{
					return Ok();
				}
				else
				{
					return NotFound();
				}
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
