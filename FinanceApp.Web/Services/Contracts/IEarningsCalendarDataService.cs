using System.Runtime.InteropServices.JavaScript;
using FinanceApp.Models.Dtos;

namespace FinanceApp.Web.Services.Contracts
{
	public interface IEarningsCalendarDataService
	{
		Task<IEnumerable<EarningsCalendarDto>> GetCalendarInfo();
	}
}
