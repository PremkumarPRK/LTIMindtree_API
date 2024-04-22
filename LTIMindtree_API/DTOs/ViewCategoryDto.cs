namespace LTIMindtree_API.DTOs
{
    public class ViewCategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string UrlHnadle { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
