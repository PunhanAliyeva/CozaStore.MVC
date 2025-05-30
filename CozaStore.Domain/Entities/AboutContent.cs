using CozaStore.MVC.Domain.Commons;

namespace CozaStore.MVC.Entities
{
	public class AboutContent:BaseEntity
	{
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string? Feedback { get; set; }
        public string? AuthorName { get; set; }
    }
}
