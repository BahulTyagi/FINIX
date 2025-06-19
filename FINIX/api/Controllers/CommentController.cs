using api.Dtos.Comment;
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
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IStockRepository _stockRepo;
        public CommentController(ICommentRepository commentRepo, IStockRepository stockRepo) 
        {
            _commentRepo=commentRepo;
            _stockRepo=stockRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllComments()
        {
            var comments=await _commentRepo.GetAllAsync();
           
            var commentDto = comments.Select(s => s.ToCommentDto());
            return Ok(commentDto);
            
        }

        [HttpGet("{id}")]
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

        [HttpPost("{id}")]
        public async Task<IActionResult> CreateComment([FromRoute]int id, [FromBody] CreateCommentDto commentDto)
        {
            if (await _stockRepo.StockExists(id))
            {
                var comment = commentDto.ToCommentFromCreateDto(id);
                await _commentRepo.CreateCommentAsync(comment);
                return CreatedAtAction(nameof(GetCommentById),new {id=comment}, comment.ToCommentDto());
            }
            else
            {
                return BadRequest();
            }

        }

    }
}
