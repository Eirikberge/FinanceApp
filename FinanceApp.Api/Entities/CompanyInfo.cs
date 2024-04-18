using System.Text.Json.Serialization;

namespace FinanceApp.Api.Entities
{
	public class CompanyInfo
	{
		public int Cik { get; set; }
		public string Name { get; set; }
		public string Ticker { get; set; }
		public string Exchange { get; set; }
	}
}
