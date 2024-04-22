using FinanceApp.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Api.Data
{
	public class FinanceAppContext : DbContext
	{
		public DbSet<Stock> Stocks { get; set; }
		public DbSet<Owner> Owners { get; set; }

		public FinanceAppContext(DbContextOptions<FinanceAppContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

		}
	}
}