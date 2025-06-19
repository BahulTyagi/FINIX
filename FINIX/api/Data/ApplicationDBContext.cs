using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions DbContextOptions) : base(DbContextOptions) 
        { 
            
        }

        public DbSet<Stock> Stocks { get; set; }

        public DbSet<Comment> Comments { get; set; }
        

       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //seeding data into table
            modelBuilder.Entity<Stock>().HasData(
                new Stock
                {
                    Id = 1,
                    Symbol = "AAPL",
                    CompanyName = "Apple Inc.",
                    Description = "Consumer electronics and software company",
                    Purchase = 150.00m,
                    LastDiv = 0.82m,
                    Industry = "Technology",
                    MarketCap = 2500000000000
                },
                new Stock
                {
                    Id = 2,
                    Symbol = "MSFT",
                    CompanyName = "Microsoft Corporation",
                    Description = "Software and cloud computing",
                    Purchase = 280.00m,
                    LastDiv = 0.75m,
                    Industry = "Technology",
                    MarketCap = 2300000000000
                } );
        }
    }
}
