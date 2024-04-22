using System.ComponentModel.DataAnnotations;

namespace LTIMindtree_API.DTOs
{
    public class AddCommentDto
    {
        [Required]
        public int BlogpostId { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Maximum Char Size is 100 Only")]
        public string CommentText { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public DateTime CreatedOn { get; set;}
    }
}
