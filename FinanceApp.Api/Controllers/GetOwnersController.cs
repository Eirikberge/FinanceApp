using Microsoft.AspNetCore.Mvc;
using FinanceApp.Api.Data;
using FinanceApp.Api.Entities;
using System.Collections.Generic;
using System.Linq;

namespace FinanceApp.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class GetOwnersController : Controller
	{
		private readonly FinanceAppDbContext _context;

		public GetOwnersController(FinanceAppDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult GetOwners()
		{
			var owners = _context.Owners.ToList();
			return Ok(owners);
		}
	}
}