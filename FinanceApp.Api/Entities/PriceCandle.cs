namespace FinanceApp.Api.Entities;

public class PriceCandle
{
	public float Current { get; set; }

	public float Open { get; set; }
	public float Close { get; set; }
	public float High { get; set; }
	public float Low { get; set; }
	public DateTime Time { get; set; }
	public string Symbol { get; set; } = null!;


}