namespace FinanceApp.Api.Entities
{
	public class Stock
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public string Symbol { get; set; } = null!;
		public float BuyingPrice { get; set; }
		public float CurrentPrice { get; set; }
		public int Qty { get; set; }

		public ICollection<Owner> Owners { get; set; } = new List<Owner>();

	}
}