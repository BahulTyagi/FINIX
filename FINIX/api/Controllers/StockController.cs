using api.Data;
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
            var stocks=_dbContext.Stocks.ToList();
            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id) 
        {
            var stocks = _dbContext.Stocks.Find(id);
            if(stocks == null)
            return NotFound();

            return Ok(stocks);
            
        }


    }
}
