using api.Data;
using api.Dtos.Comment;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public CommentRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Comment> CreateCommentAsync(Comment comment)
        {
            await _dbContext.Comments.AddAsync(comment);
            await _dbContext.SaveChangesAsync();

            return comment;

        }

        public async Task<Comment?> DeleteCommmentAsync(int id)
        {
            var comment = await _dbContext.Comments.FirstOrDefaultAsync(x => x.Id == id);
            if (comment == null)
                return null;

            _dbContext.Comments.Remove(comment);
            _dbContext.SaveChangesAsync();

            return comment;

        }

        public async Task<List<Comment>?> GetAllAsync()
        {
            return await _dbContext.Comments.ToListAsync();  
        }

        public async Task<Comment?> GetCommentByIdAsync(int id)
        {
            return await _dbContext.Comments.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Comment?> UpdateCommentAsync(int id, CreateCommentDto comment)
        {
            var getcomment = await _dbContext.Comments.FirstOrDefaultAsync(x => x.Id == id);

            if (getcomment == null)
                return null;
            else
            {
                getcomment.Title = comment.Title;
                getcomment.Content = comment.Content;

               await _dbContext.SaveChangesAsync();
                return getcomment;
            }
        }
    }
}
