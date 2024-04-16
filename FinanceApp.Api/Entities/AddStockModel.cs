namespace FinanceApp.Api.Entities
{
	public class AddStockModel
	{
		public string Name { get; set; }
		public string Symbol { get; set; }
		public float BuyingPrice { get; set; }
		public float CurrentPrice { get; set; }
		public int Qty { get; set; }
	}
}
