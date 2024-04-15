using Microsoft.VisualBasic;

namespace FinanceApp.Api.Entities
{
	public class EarningsSurprises
	{
		public float Actual { get; set; }
		public float Estimate { get; set; }
		public string Period { get; set; }
		public float Quarter { get; set; }
		public float Surprice { get; set; }
		public float SurpricePercent { get; set; }
		public string Symbol { get; set; } = null!;
		public float Year { get; set; }

	}
}