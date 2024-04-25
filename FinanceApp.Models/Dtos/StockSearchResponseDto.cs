using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApp.Models.Dtos
{
	public class StockSearchResponseDto
	{
			public string Name { get; set; }
			public float Current { get; set; }
			public float Open { get; set; }
			public float Previous { get; set; }
			public float High { get; set; }
			public float Low { get; set; }
			public float PercentChange { get; set; }
			public float Change { get; set; }
			public string Symbol { get; set; }
	}
}
