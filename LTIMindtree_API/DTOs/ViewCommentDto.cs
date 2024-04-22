namespace LTIMindtree_API.DTOs
{
    public class ViewCommentDto
    {
        public string CommentText { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set;}
        public int BlogpostId { get; set; }
    }
}
