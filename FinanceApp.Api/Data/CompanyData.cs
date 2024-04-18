using System.Collections.Generic;

namespace FinanceApp.Api.Entities
{
	public class CompanyData
	{
		public List<string> Fields { get; set; }
		public List<List<object>> Data { get; set; }
	}
}