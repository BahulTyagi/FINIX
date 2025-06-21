using api.Extensions;
using api.Interfaces;
using api.Models;
using api.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IStockRepository _stockRepository;

        private readonly IPortfolioRepository _portfolioRepo;
        private readonly IFMPService _fmpService;

        public PortfolioController(IFMPService FMPService ,UserManager<AppUser> userManager, IStockRepository stockRepo, IPortfolioRepository portfolioRepository)
        {
            _stockRepository = stockRepo;
            _userManager = userManager;
            _portfolioRepo= portfolioRepository;
            _fmpService = FMPService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserPortfolio() 
        {
            var username = User.GetUserName();
            var appUser=await _userManager.FindByNameAsync(username);
            var userPortfolio = await _portfolioRepo.GetUserPortfolio(appUser);
            return Ok(userPortfolio);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPorfolio([FromBody] string symbol)
        {
            var username=User.GetUserName();
            var appUser= await _userManager.FindByNameAsync(username);
            var stock= await _stockRepository.GetBySymbolAsync(symbol);

            if (stock == null)
            {
                stock = await _fmpService.FindStockBySymbolAsync(symbol);
                if (stock == null)
                    return BadRequest("Stock doesnt exist");
                else
                    await _stockRepository.CreateAsync(stock);
            }


            if (stock == null)
                return BadRequest("stock not found");

            var userPortfolio = await _portfolioRepo.GetUserPortfolio(appUser);

            if (userPortfolio.Any(e => e.Symbol.ToLower() == symbol.ToLower()))
            {
                return BadRequest("cannot add same stock in the portfolio again");
            }

            var portfolioModel = new Portfolio
            {
                StockId = stock.Id,
                AppUserId = appUser.Id,
            };

            var createdPortfolio=await _portfolioRepo.CreateAsync(portfolioModel);
            if (createdPortfolio == null)
                return BadRequest("Failed to create  portfolio");
            else 
                return Ok(createdPortfolio);
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeletePortfolio(string symbol)
        {
            var username = User.GetUserName();
            var appUser = await _userManager.FindByNameAsync(username);

            var userPortfolio = await _portfolioRepo.GetUserPortfolio(appUser);
            var filteredStock = userPortfolio.Where(x => x.Symbol.ToLower() == symbol.ToLower());

            if(filteredStock.Count()==1)
            {
                var portfolio=await _portfolioRepo.DeletePortfolioAsync(appUser, symbol);

            }
            else 
            {
                return BadRequest("Stock is not in the portfolio");
            }
            return Ok();
        }
    }
}
