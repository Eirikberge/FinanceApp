namespace FinanceApp.Api.Entities
{
	public class StockUpdateModel
	{
		public string Symbol { get; set; }
		public float NewPrice { get; set; }
		public int NewQty { get; set; }
	}
}
