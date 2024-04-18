using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using FinanceApp.Api.Entities;

namespace FinanceApp.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CompanyInfoController : Controller
	{
		[HttpGet]
		public ActionResult<IEnumerable<CompanyInfo>> Get()
		{
			try
			{
				var jsonString = System.IO.File.ReadAllText("CompanyTickerCik.json");

				using (JsonDocument jsonDocument = JsonDocument.Parse(jsonString)) // Måtte bruke JsonDocument!!!
				{
					JsonElement root = jsonDocument.RootElement;

					if (root.TryGetProperty("data", out JsonElement dataElement))
					{
						var companyInfoList = new List<CompanyInfo>();
						foreach (JsonElement companyInfoElement in dataElement.EnumerateArray())
						{
							var companyInfo = new CompanyInfo
							{
								Cik = companyInfoElement[0].GetInt32(),
								Name = companyInfoElement[1].GetString(),
								Ticker = companyInfoElement[2].GetString(),
								Exchange = companyInfoElement[3].GetString()
							};
							companyInfoList.Add(companyInfo);
						}

						return Ok(companyInfoList);
					}
					else
					{
						return BadRequest("Unable to find 'data' property in JSON.");
					}
				}
			}
			catch (FileNotFoundException)
			{
				return NotFound("JSON file not found.");
			}
			catch (JsonException)
			{
				return BadRequest("Invalid JSON format");
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}
	}
}