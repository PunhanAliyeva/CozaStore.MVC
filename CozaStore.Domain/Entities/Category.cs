
using CozaStore.MVC.Domain.Commons;

namespace CozaStore.MVC.Entities
{
	public class Category:BaseEntity
	{
        public string Name { get; set; }
        public string Concept { get; set; }
        public string ImageUrl { get; set; }
        public List<Product> Products { get; set; }
        public int? ParentId { get; set; }
        public Category? Parent { get; set; }   
        public ICollection<Category> SubCategories { get; set; } = new List<Category>(); 
    }
}
