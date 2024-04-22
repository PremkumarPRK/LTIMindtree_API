namespace LTIMindtree_API.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set;}

        public int BlogpostId { get; set; }
    }
}
