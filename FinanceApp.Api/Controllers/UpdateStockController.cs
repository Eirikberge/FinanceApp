using FinanceApp.Api.Data;
using FinanceApp.Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FinanceApp.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UpdateStockController : Controller
	{
		private readonly FinanceAppContext _context;

		public UpdateStockController(FinanceAppContext context)
		{
			_context = context;
		}

		[HttpPut("api/updateqty")]
		public IActionResult UpdateQty([FromBody] StockUpdateModel updateModel)
		{
			return UpdateStock(updateModel.Symbol, stock => stock.Qty = updateModel.NewQty);

		}

		private IActionResult UpdateStock(string symbol, Action<Stock> updateAction)
		{
			var stock = _context.Stocks.FirstOrDefault(s => s.Symbol == symbol);

			if (stock == null)
			{
				return NotFound();
			}

			updateAction(stock);

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
