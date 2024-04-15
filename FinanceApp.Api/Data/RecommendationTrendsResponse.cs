using System.Text.Json;
using System.Text.Json.Serialization;

namespace FinanceApp.Data
{
	public class RecommendationTrendsResponse
	{
		[JsonPropertyName("buy")]

		public float Buy { get; set; }
		[JsonPropertyName("hold")]

		public int Hold { get; set; }
		[JsonPropertyName("period")]

		public string Period { get; set; } = null!;
		[JsonPropertyName("sell")]

		public float Sell { get; set; }
		[JsonPropertyName("strongBuy")]

		public float StrongBuy { get; set; }
		[JsonPropertyName("strongSell")]

		public float StrongSell { get; set; }
		[JsonPropertyName("symbol")]

		public string Symbol { get; set; } = null!;
	}
}