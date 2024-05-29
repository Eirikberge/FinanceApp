using FinanceApp.Models.Dtos;
using FinanceApp.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace FinanceApp.Web.Pages
{
	public class CompanyDetailsBase : ComponentBase
	{
		[Parameter] public string Symbol { get; set; }

		[Inject] public IEarningsCalendarDataService CalendarInfoService { get; set; }
		public IEnumerable<EarningsCalendarDto> EarningsCalendarEvents { get; set; }

		protected override async Task OnInitializedAsync()
		{
			EarningsCalendarEvents = await CalendarInfoService.GetCalendarInfo();
		}
	}
}

