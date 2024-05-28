using FinanceApp.Web.Services;
using FinanceApp.Web.Services.Contracts;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace FinanceApp.Web
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("#app");
			builder.RootComponents.Add<HeadOutlet>("head::after");

			builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
			
			builder.Services.AddScoped<ITradeService, TradeService>();
			builder.Services.AddScoped<ICompanyInfoService, CompanyInfoService>();
			builder.Services.AddScoped<ICalendarInfoService, CalendarInfoService>();
			builder.Services.AddScoped<IUserService, UserService>();

			await builder.Build().RunAsync();
		}
	}
}
