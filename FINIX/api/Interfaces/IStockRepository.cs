using api.Dtos.Stock;
using api.Helper;
using api.Models;

namespace api.Interfaces
{
    public interface IStockRepository
    {
        public Task<List<Stock?>> GetAllAsync(QueryObject query);

        public Task<Stock?> GetByIdAsync(int id);

        public Task<Stock?> CreateAsync(Stock stock);

        public Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto);

        public Task<Stock?> DeleteAsync(int id);

        public Task<bool> StockExists(int id); 

        public Task<Stock?> GetBySymbolAsync(string symbol);
    }
}
