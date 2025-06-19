    using api.Data;
    using api.Dtos.Stock;
    using api.Interfaces;
    using api.Mapper;
    using api.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    namespace api.Repository
    {
        public class StockRepository : IStockRepository
        {
            private readonly ApplicationDBContext _dbContext;
            public StockRepository(ApplicationDBContext dBContext)
            {
                _dbContext = dBContext;
            }


            public async Task<List<Stock>> GetAllAsync()
            {
                var stocks = await _dbContext.Stocks.Include(c=>c.comment).ToListAsync();
                return stocks;

            }

            public async Task<Stock?> CreateAsync(Stock stock)
            {
                await _dbContext.Stocks.AddAsync(stock);
                await _dbContext.SaveChangesAsync();

                return stock;

            }

            public async Task<Stock?> DeleteAsync(int id)
            {

                try
                {
                    var stock = await _dbContext.Stocks.FirstOrDefaultAsync(s => s.Id == id) ;
            
                    if (stock == null)
                        return null;
                    else
                    {
                        _dbContext.Stocks.Remove(stock); // Remove is not an asynchronous func,dont know why
                        await _dbContext.SaveChangesAsync();
                        return stock;
                    }
                }
            
                catch(Exception ex)
                {
                    Console.WriteLine("ex: " + ex.ToString());
                }
                return null;
            }

            public async Task<Stock?> GetByIdAsync(int id)
            {
                return await _dbContext.Stocks.Include(c => c.comment).FirstOrDefaultAsync(i=>i.Id==id);
            }

            public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto updateStockDto)
            {
                var stock= await _dbContext.Stocks.FirstOrDefaultAsync(x => x.Id == id);

                if (stock == null)
                    return null;
                else
                {
                    stock.Symbol = updateStockDto.Symbol;
                    stock.CompanyName = updateStockDto.CompanyName;
                    stock.MarketCap = updateStockDto.MarketCap;
                    stock.Purchase = updateStockDto.Purchase;
                    stock.Description = updateStockDto.Description;
                    stock.LastDiv = updateStockDto.LastDiv;
                    stock.Industry = updateStockDto.Industry;

                    await _dbContext.SaveChangesAsync();

                    return stock;

                }
            }

        public async Task<bool> StockExists(int id)
        {
            return await _dbContext.Stocks.AnyAsync(x => x.Id==id);
        }
    }
    }
