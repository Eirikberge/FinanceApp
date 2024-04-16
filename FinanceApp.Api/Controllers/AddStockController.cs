using FinanceApp.Api.Data;
using FinanceApp.Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FinanceApp.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AddStockController : Controller
	{
		private readonly FinanceAppDbContext _context;

		public AddStockController(FinanceAppDbContext context)
		{
			_context = context;
		}

		[HttpPost("api/addstock")]
		public async Task<IActionResult> AddStock([FromBody] AddStockModel addModel)
		{
			try
			{
				var stock = new Stock
				{
					Name = addModel.Name,
					Symbol = addModel.Symbol,
					BuyingPrice = addModel.BuyingPrice,
					CurrentPrice = addModel.CurrentPrice,
					Qty = addModel.Qty
				};

				_context.Stocks.Add(stock);
				await _context.SaveChangesAsync();

				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
