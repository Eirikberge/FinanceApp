namespace FinanceApp.Api.Entities
{
	public class Owner
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;

		public ICollection<Stock> Stocks { get; set; } = new List<Stock>();
	}
}
