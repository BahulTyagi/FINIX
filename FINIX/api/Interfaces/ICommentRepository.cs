using api.Dtos.Comment;
using api.Models;

namespace api.Interfaces
{
    public interface ICommentRepository
    {
        public Task<List<Comment>?> GetAllAsync();

        public Task<Comment?> GetCommentByIdAsync(int id);

        public Task<Comment?> CreateCommentAsync(Comment comment);

        public Task<Comment?> DeleteCommmentAsync(int id);

        public Task<Comment?> UpdateCommentAsync(int id, CreateCommentDto comment);
    }
}
