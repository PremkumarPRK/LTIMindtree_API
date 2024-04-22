namespace LTIMindtree_API.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string? Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public ICollection<Blogpost> Blogposts { get; set; }
    }
}
