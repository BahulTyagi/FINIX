using api.Models;

namespace api.Interfaces
{
    public interface ICommentRepository
    {
        public Task<List<Comment>?> GetAllAsync();

        public Task<Comment?> GetCommentByIdAsync(int id);

        public Task<Comment> CreateCommentAsync(Comment comment);
    }
}
