
using CozaStore.Domain.Commons;

namespace CozaStore.Domain.Entities
{
	public class ProductSizes:BaseEntity
	{
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int SizeId { get; set; }
        public Size Size { get; set; }
    }
}
