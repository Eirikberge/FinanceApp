using Microsoft.AspNetCore.Mvc;
using FinanceApp.Api.Data;
using FinanceApp.Api.Entities;
using System.Collections.Generic;
using System.Linq;
using FinanceApp.Api.Repositorys.Contracts;

namespace FinanceApp.Controllers
{
	[ApiController]
	[Route("api/getstocks")]
	public class GetStocksController : Controller
	{
		private readonly IStockRepository _stockRepository;

		public GetStocksController(IStockRepository stockRepository)
		{
			_stockRepository = stockRepository;
		}

		[HttpGet]
		public async Task<IActionResult> GetStocks()
		{
			var stocks = await _stockRepository.GetStocks();
			return Ok(stocks);
		}
	}
}