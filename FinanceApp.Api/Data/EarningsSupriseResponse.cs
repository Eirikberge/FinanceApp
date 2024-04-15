using System.Text.Json;
using System.Text.Json.Serialization;

namespace FinanceApp.Data
{
	public class EarningsSupriseResponse
	{
		[JsonPropertyName("actual")]
		public float Actual { get; set; }
		[JsonPropertyName("estimate")]
		public float Estimate { get; set; }
		[JsonPropertyName("period")]
		public string Period { get; set; }
		[JsonPropertyName("quarter")]
		public float Quarter { get; set; }
		[JsonPropertyName("surprise")]
		public float Surprise { get; set; }
		[JsonPropertyName("surpricePercent")]
		public float SurprisePercent { get; set; }
		[JsonPropertyName("symbol")]
		public string Symbol { get; set; }
		[JsonPropertyName("year")]
		public float Year { get; set; }

	}
}