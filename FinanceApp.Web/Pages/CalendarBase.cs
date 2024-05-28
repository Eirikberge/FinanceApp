using FinanceApp.Models.Dtos;
using FinanceApp.Web.Services.Contracts;
using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace FinanceApp.Web.Pages
{
	public class CalendarBase : ComponentBase
	{

		[Inject]
		public ICalendarInfoService CalendarInfoService { get; set; }
		public IEnumerable<EarningsCalendarDto> EarningsCalendarEvents { get; set; }

		protected override async Task OnInitializedAsync()
		{
			EarningsCalendarEvents = await CalendarInfoService.GetCalendarInfo();

		}
		public static string GetMonthAsString()
		{
			int targetMonth = (DateTime.Now.Month - 1) % 12 + 1;

			string currentMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(targetMonth); var capitalizedMonth = currentMonth.Substring(0, 1).ToUpper() + currentMonth.Substring(1);
			return capitalizedMonth;
		}
	}
}
