using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Comment
{
    public class CreateCommentDto
    {
        [Required]
        [MinLength(5, ErrorMessage ="Title cant be less than 5 characters")]
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }
}
