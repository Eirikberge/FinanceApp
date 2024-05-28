using FinanceApp.Models.Dtos;

namespace FinanceApp.Web.Services.Contracts
{
	public interface IUserService
	{
		Task<IEnumerable<UserDto>> GetUsers();
	}
}
