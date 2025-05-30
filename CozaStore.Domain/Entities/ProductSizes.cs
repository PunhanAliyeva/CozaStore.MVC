
using CozaStore.MVC.Domain.Commons;

namespace CozaStore.MVC.Entities
{
	public class ProductSizes:BaseEntity
	{
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int SizeId { get; set; }
        public Size Size { get; set; }
    }
}
