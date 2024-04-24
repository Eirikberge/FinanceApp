using System.Text.Json.Serialization;

namespace FinanceApp.Api.Entities
{
	public class BasicFinancialsModel
	{
		[JsonPropertyName("beta")]
		public float Beta { get; set; }

		[JsonPropertyName("dividendGrowthRate5Y")]
		public double DividendGrowthRate5Y { get; set;}

		[JsonPropertyName("dividendPerShareAnnual")]
		public float DividendPerShareAnnual { get; set; }
	}
}
