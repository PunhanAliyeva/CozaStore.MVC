
using CozaStore.Domain.Commons;

namespace CozaStore.Domain.Entities
{
	public class ProductImage:BaseEntity
	{
        public string ImageUrl { get; set; }
		public bool IsMain { get; set; }
		public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
