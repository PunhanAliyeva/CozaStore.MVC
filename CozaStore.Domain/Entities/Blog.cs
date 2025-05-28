
using CozaStore.MVC.Domain.Commons;

namespace CozaStore.MVC.Models.Entities
{
	public class Blog:BaseEntity
	{
        public string Concept { get; set; }
        public string? Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Time { get; set; }
        public string? AuthorName { get; set; }
        public int BlogCategoryId { get; set; }
        public BlogCategory BlogCategory { get; set; }
        public List<BlogTags> BlogTags { get; set; }
    }
}
