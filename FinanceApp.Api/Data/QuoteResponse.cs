using System.Text.Json;
using System.Text.Json.Serialization;

namespace FinanceApp.Data;

public class QuoteResponse
{
	[JsonPropertyName("c")]
	public float Current { get; set; }

	[JsonPropertyName("h")]
	public float High { get; set; }

	[JsonPropertyName("o")]
	public float Open { get; set; }

	[JsonPropertyName("pc")]
	public float Previous { get; set; }

	[JsonPropertyName("dp")]
	public float PercentChange { get; set; }

	[JsonPropertyName("l")]
	public float Low { get; set; }

	[JsonPropertyName("d")]
	public float Change { get; set; }
}