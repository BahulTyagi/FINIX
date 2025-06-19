using api.Dtos.Stock;
using api.Models;

namespace api.Mapper
{
    public static class StockMappers
    {
        public static StockDto ToStockDto(this Stock stockModel)
        {
            return new StockDto
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Description = stockModel.Description,
                Industry = stockModel.Industry,
                Purchase = stockModel.Purchase,
                LastDiv = stockModel.LastDiv,
                MarketCap = stockModel.MarketCap
            };
        }


        public static Stock ToCreateStockRequestDto(this CreateStockRequestDto requestDto)
        {
            return new Stock
            {
                Symbol = requestDto.Symbol,
                CompanyName = requestDto.CompanyName,
                Description = requestDto.Description,
                Industry = requestDto.Industry,
                Purchase = requestDto.Purchase,
                LastDiv = requestDto.LastDiv,
                MarketCap = requestDto.MarketCap
            };
        }
    }
}
