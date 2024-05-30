using FinanceApp.Models.Dtos;

namespace FinanceApp.Web.Services.Contracts
{
	public interface IBasicFinancialDataService
	{
		Task<BasicFinancialsDto> GetBasicFinancialsData(string symbol);
	}
}
