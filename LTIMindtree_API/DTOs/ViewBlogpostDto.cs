namespace LTIMindtree_API.DTOs
{
    public class ViewBlogpostDto
    {
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

        public List<ViewCategoryDto> Categories { get; set; } = new List<ViewCategoryDto>();
    }
}
