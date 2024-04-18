namespace FinanceApp.Web
{
	public class Models
	{
	}

	public class Stock
	{
		public string Name { get; set; }
		public string Symbol { get; set; }
		public float BuyingPrice { get; set; }
		public float CurrentPrice { get; set; }
		public int Qty { get; set; }
	}

	public class StockSearchResponse
	{
		public string Name { get; set; }
		public float Current { get; set; }
		public float Open { get; set; }
		public float Previous { get; set; }
		public float High { get; set; }
		public float Low { get; set; }
		public float PercentChange { get; set; }
		public float Change { get; set; }
		public string Time { get; set; }
		public string Symbol { get; set; }
	}

	public class CompanyInfoResponse
	{
		public int Cik { get; set; }
		public string Name { get; set; }
		public string Ticker { get; set; }
		public string Exchange { get; set; }

	}
}
