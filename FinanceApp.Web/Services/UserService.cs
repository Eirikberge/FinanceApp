using FinanceApp.Models.Dtos;
using FinanceApp.Web.Services.Contracts;
using System.Net.Http.Json;

namespace FinanceApp.Web.Services
{
	public class UserService : IUserService
	{
		private readonly HttpClient _httpClient;

		public UserService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<IEnumerable<UserDto>> GetUsers()
		{
			try
			{
				var users = await _httpClient.GetFromJsonAsync<IEnumerable<UserDto>>("https://localhost:7282/api/User");
				return users;
			}
			catch (Exception ex)
			{
				throw;
			}
		}
	}
}

