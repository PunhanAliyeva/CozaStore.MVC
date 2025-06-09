
using CozaStore.Domain.Commons;

namespace CozaStore.Domain.Entities
{
	public class Category:BaseEntity
	{
        public string Name { get; set; }
        public string Concept { get; set; }
        public string ImageUrl { get; set; }
        public List<Product> Products { get; set; }
        public int? ParentId { get; set; }
        public Category? Parent { get; set; }
    }
}
