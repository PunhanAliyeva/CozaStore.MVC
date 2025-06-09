
using CozaStore.Domain.Commons;

namespace CozaStore.Domain.Entities
{
	public class ProductTags:BaseEntity
	{
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
