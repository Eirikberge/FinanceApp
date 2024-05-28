using System.Runtime.InteropServices.JavaScript;
using FinanceApp.Models.Dtos;

namespace FinanceApp.Web.Services.Contracts
{
	public interface ICalendarInfoService
	{
		Task<IEnumerable<EarningsCalendarDto>> GetCalendarInfo();
	}
}
