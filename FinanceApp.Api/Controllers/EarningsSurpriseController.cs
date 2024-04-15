using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using FinanceApp.Data;
using FinanceApp.Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FinanceApp.Controllers
{
	[ApiController]
	[Route("earningssurprise")]
	public class EarningsSurpriseController : Controller
	{
		private readonly HttpClient _client;

		public EarningsSurpriseController()
		{
			_client = new HttpClient();
		}

		[Route("")]
		[HttpGet]
		public IActionResult Index()
		{
			return Ok();
		}

		[HttpGet("{symbol}")]

		public async Task<IActionResult> GetEarningsSurprise(string symbol)
		{
			var request = new HttpRequestMessage(HttpMethod.Get, $"https://finnhub.io/api/v1/stock/earnings?symbol={symbol}");
			request.Headers.Add("X-Finnhub-Token", "co5tdu1r01qv77g7q8bgco5tdu1r01qv77g7q8c0");

			var response = await _client.SendAsync(request);

			if (!response.IsSuccessStatusCode)
			{
				return BadRequest();
			}

			var content = await response.Content.ReadAsStringAsync();
			var earningsSurprise = JsonSerializer.Deserialize<List<EarningsSupriseResponse>>(content);

			return Ok(earningsSurprise);
		}
	}
}