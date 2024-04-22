using System.ComponentModel.DataAnnotations.Schema;

namespace LTIMindtree_API.Models
{
    public class Blogpost
    {
        public int BlogpostId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public string Imageurl { get; set; }
        public string UrlHandle { get; set; }
        public string Author { get; set; }
        public DateTime PublishedDate { get; set; }
        public bool IsVisible { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
