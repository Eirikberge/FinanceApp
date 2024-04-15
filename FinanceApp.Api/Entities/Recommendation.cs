using System.Runtime.InteropServices.JavaScript;

namespace FinanceApp.Api.Entities
{
	public class Recommendation
	{
		public float Buy { get; set; }
		public int Hold { get; set; }
		public string Period { get; set; }
		public float Sell { get; set; }
		public float StrongBuy { get; set; }
		public float StrongSell { get; set; }
		public string Symbol { get; set; } = null!;

	}
}