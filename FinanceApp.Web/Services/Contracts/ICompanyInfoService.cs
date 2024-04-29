using FinanceApp.Models.Dtos;

namespace FinanceApp.Web.Services.Contracts
{
	public interface ICompanyInfoService
	{
		Task<IEnumerable<CompanyInfoDto>> GetCompanyInfo();
	}
}
