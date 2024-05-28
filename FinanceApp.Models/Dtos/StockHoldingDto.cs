namespace FinanceApp.Models.Dtos
{
	internal class StockHoldingDto
	{
		public string StockSymbol { get; set; }
		public int Quantity { get; set; }
		public int UserID { get; set; } // FK
		public float Price { get; set; }
	}
}
