using api.Dtos.Account;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;

        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;   
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto regis)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState); // this is to check if all the data validation like [Required], etc are valid
                }

                var appuser = new AppUser
                {
                    UserName = regis.Username,
                    Email = regis.Email,
                };

                var createdUser= await _userManager.CreateAsync(appuser, regis.Password);
                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appuser, "User");
                    if (roleResult.Succeeded)
                    {
                        return Ok(new NewUserDto { Email= appuser.Email, UserName=appuser.Email, Token=_tokenService.CreateToken(appuser)});
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else 
                {
                    return StatusCode (500, createdUser.Errors);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

    }
}
