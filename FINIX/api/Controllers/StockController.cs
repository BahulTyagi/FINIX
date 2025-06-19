using api.Data;
using api.Dtos.Stock;
using api.Interfaces;
using api.Mapper;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly IStockRepository _stockRepository;

        public StockController(ApplicationDBContext dbcontext, IStockRepository stockRepo)
        {
            _dbContext = dbcontext;
            _stockRepository = stockRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stocks = await _stockRepository.GetAllAsync();

            var stockDto=stocks.Select(item => item.ToStockDto());
            return Ok(stockDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var stocks = await _stockRepository.GetByIdAsync(id);
            if (stocks == null)
                return NotFound();

            return Ok(stocks.ToStockDto());

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
        {
            var stock = stockDto.ToCreateStockRequestDto();
            await _stockRepository.CreateAsync(stock);
            return CreatedAtAction(nameof(GetById), new { Id = stock.Id }, stock.ToStockDto());
        }
        // Patch updates only the required part, while put updates the entire document.
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStock([FromRoute] int id, [FromBody] UpdateStockRequestDto updateStockDto)
        {
            var stock = await _stockRepository.UpdateAsync(id, updateStockDto);
            if (stock == null)
                return NotFound();
            else
                return Ok(stock.ToStockDto());

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStock([FromRoute] int id)
        {
            var stock = _stockRepository.DeleteAsync(id);
            if (stock == null)
                return NotFound();
            else
                return NoContent();
        }

    }
}
