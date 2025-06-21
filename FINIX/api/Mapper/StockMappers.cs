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
                MarketCap = stockModel.MarketCap,
                comment = stockModel.comment.Select(x => x.ToCommentDto()).ToList()
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

        public static Stock ToStockFromFMP(this FMPStock requestDto)
        {
            return new Stock
            {
                Symbol = requestDto.symbol,
                CompanyName = requestDto.companyName,
                Description = requestDto.description,
                Industry = requestDto.industry,
                Purchase = (decimal)requestDto.price,
                LastDiv = (decimal)requestDto.lastDividend,
                MarketCap = requestDto.marketCap
            };
        }
    }
}
