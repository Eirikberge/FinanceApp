using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace FinanceApp.Web.Pages
{
	public class CalendarBase : ComponentBase
	{
		private static int monthChange = 0;

		public static string GetMonthAsString()
		{
			int targetMonth = (DateTime.Now.Month + monthChange - 1) % 12 + 1;

			string currentMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(targetMonth); var capitalizedMonth = currentMonth.Substring(0, 1).ToUpper() + currentMonth.Substring(1);
			return capitalizedMonth;
		}
	}
}
