using Microsoft.AspNetCore.Mvc;
using FinanceApp.Api.Data;
using FinanceApp.Api.Entities;
using System.Collections.Generic;
using System.Linq;

namespace FinanceApp.Controllers
{
	[ApiController]
	[Route("api/getstocks")]
	public class GetStocksController : Controller
	{
		private readonly FinanceAppDbContext _context;

		public GetStocksController(FinanceAppDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult GetOwners()
		{
			var stocks = _context.Stocks.ToList();
			return Ok(stocks);
		}
	}
}