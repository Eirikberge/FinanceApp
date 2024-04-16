using FinanceApp.Api.Data;
using FinanceApp.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Api.Controllers
{
    [ApiController]
	[Route("[controller]")]
	public class UpdateStockPriceController : Controller
	{
		private readonly FinanceAppDbContext _context;

		public UpdateStockPriceController(FinanceAppDbContext context)
		{
			_context = context;
		}
		[HttpPut("api/updatestock")]
		public IActionResult UpdateStock([FromBody] StockUpdateModel updateModel)
		{
			var stock = _context.Stocks.FirstOrDefault(s => s.Symbol == updateModel.Symbol);

			if (stock == null)
			{
				return NotFound();
			}

			stock.CurrentPrice = updateModel.NewPrice;

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
