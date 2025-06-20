using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions DbContextOptions) : base(DbContextOptions) 
        { 
            
        }

        public DbSet<Stock> Stocks { get; set; }

        public DbSet<Comment> Comments { get; set; }
        

       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


             modelBuilder.Entity<Comment>().HasData(
                new Comment
                {
                    Id = 1,
                    Title = "Apple News",
                    Content = "Apple launches new iPhone.",
                    CreatedOn = new DateTime(2024, 10, 5),
                    StockId = 10
                }, new Comment
                {
                    Id = 3,
                    Title = "Market Overview",
                    Content = "Stocks fluctuate after Fed announcement.",
                    CreatedOn = new DateTime(2024, 12, 1),
                    StockId = 20 
                });


        //seeding data into table
        modelBuilder.Entity<Stock>().HasData(
                new Stock
                {
                    Id = 10,
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
                    Id = 20,
                    Symbol = "MSFT",
                    CompanyName = "Microsoft Corporation",
                    Description = "Software and cloud computing",
                    Purchase = 280.00m,
                    LastDiv = 0.75m,
                    Industry = "Technology",
                    MarketCap = 2300000000000
                } );



            modelBuilder.Entity<IdentityRole>().HasData(
                new List<IdentityRole>
                {
                    new IdentityRole {
                        Id="1",
                        Name="Admin",
                        NormalizedName="ADMIN",
                        ConcurrencyStamp="hey"
                    },
                    new IdentityRole
                    {
                        Id="2",
                        Name="User",
                        NormalizedName="USER",
                        ConcurrencyStamp="hello"
                    }
                }
               );
        }


    }
}
