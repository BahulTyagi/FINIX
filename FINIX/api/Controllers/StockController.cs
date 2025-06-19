using api.Data;
using api.Dtos.Stock;
using api.Mapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;

        public StockController(ApplicationDBContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var stocks = _dbContext.Stocks.ToList()
                        .Select(item => item.ToStockDto());
            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var stocks = _dbContext.Stocks.Find(id);
            if (stocks == null)
                return NotFound();

            return Ok(stocks.ToStockDto());

        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateStockRequestDto stockDto)
        {
            var stock = stockDto.ToCreateStockRequestDto();
            _dbContext.Stocks.Add(stock);
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { Id = stock.Id }, stock.ToStockDto());
        }
        // Patch updates only the required part, while put updates the entire document.
        [HttpPut("{id}")]
        public IActionResult UpdateStock([FromRoute] int id, [FromBody] UpdateStockRequestDto updateStockDto)
        {
            var stock = _dbContext.Stocks.FirstOrDefault(x => x.Id == id);
            if (stock == null)
                return NotFound();
            else
            {
                stock.Symbol = updateStockDto.Symbol;
                stock.CompanyName = updateStockDto.CompanyName;
                stock.MarketCap = updateStockDto.MarketCap;
                stock.Purchase = updateStockDto.Purchase;
                stock.Description = updateStockDto.Description;
                stock.LastDiv = updateStockDto.LastDiv;
                stock.Industry = updateStockDto.Industry;

                _dbContext.SaveChanges();

                return Ok(stock.ToStockDto());

            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStock([FromRoute] int id)
        {
            var stock = _dbContext.Stocks.FirstOrDefault(x => x.Id == id);
            if (stock == null)
                return NotFound();
            else 
            {
                _dbContext.Stocks.Remove(stock);

                _dbContext.SaveChanges();
                return NoContent();
            }
        }




    }
}
