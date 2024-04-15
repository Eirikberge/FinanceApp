using FinanceApp.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Api.Data
{
	public class FinanceAppDbContext : DbContext
	{
		public DbSet<Stock> Stocks { get; set; }
		public DbSet<Owner> Owners { get; set; }

		public FinanceAppDbContext(DbContextOptions<FinanceAppDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

		}
	}
}