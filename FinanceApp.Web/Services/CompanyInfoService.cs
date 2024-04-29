using System.Net.Http.Json;
using FinanceApp.Models.Dtos;
using FinanceApp.Web.Services.Contracts;

namespace FinanceApp.Web.Services
{
	public class CompanyInfoService : ICompanyInfoService
	{
		private readonly HttpClient _httpClient;
		public CompanyInfoService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task<IEnumerable<CompanyInfoDto>> GetCompanyInfo()
		{
			try
			{
				var companyInfo = await _httpClient.GetFromJsonAsync<IEnumerable<CompanyInfoDto>>("https://localhost:7282/CompanyInfo");
				return companyInfo;
			}
			catch (Exception ex)
			{
				throw;
			}
		}
	}


}
