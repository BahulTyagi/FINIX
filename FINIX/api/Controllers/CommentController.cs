using api.Dtos.Comment;
using api.Extensions;
using api.Interfaces;
using api.Mapper;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IStockRepository _stockRepo;
        private readonly UserManager<AppUser> _usermanager;
        private readonly IFMPService _fmpService;
        public CommentController(IFMPService fMPService ,ICommentRepository commentRepo, IStockRepository stockRepo, UserManager<AppUser> userManager) 
        {
            _commentRepo=commentRepo;
            _stockRepo=stockRepo;
            _usermanager=userManager;
            _fmpService=fMPService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllComments()
        {
            var comments=await _commentRepo.GetAllAsync();
           
            var commentDto = comments.Select(s => s.ToCommentDto());
            return Ok(commentDto);
            
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCommentById(int id)
        { 
            var comment=await _commentRepo.GetCommentByIdAsync(id);
            if (comment == null)
                return NotFound();
            else 
            {
                return Ok(comment.ToCommentDto());
            }
        }

        [HttpPost("{symbol:int}")]
        public async Task<IActionResult> CreateComment([FromRoute]string symbol, [FromBody] CreateCommentDto commentDto)
        {
            if (!ModelState.IsValid) { 
                return BadRequest(ModelState);
            }

            var stock= await _stockRepo.GetBySymbolAsync(symbol);


            if (stock==null)
            {
                stock= await _fmpService.FindStockBySymbolAsync(symbol);
                if(stock==null)
                    return BadRequest("Stock doesnt exist");
                else
                    await _stockRepo.CreateAsync(stock);
            }
                var username = User.GetUserName();
                var appUser = await _usermanager.FindByNameAsync(username);

                var comment = commentDto.ToCommentFromCreateDto(stock.Id);
                comment.AppUserId = appUser.Id;
                await _commentRepo.CreateCommentAsync(comment);
                return CreatedAtAction(nameof(GetCommentById), new { id = comment.Id }, comment.ToCommentDto());

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteComment([FromRoute]  int id)
        {
            var comment = await _commentRepo.DeleteCommmentAsync(id);

            if (comment == null)
                return NotFound();
            else
                return Ok(comment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment([FromRoute] int id, [FromBody] CreateCommentDto comment)
        {
            var getcomment = await _commentRepo.UpdateCommentAsync(id, comment);

            if (comment == null)
                return NotFound();
            else
                return Ok(comment);
        }


    }
}
