
using CozaStore.Domain.Commons;

namespace CozaStore.Domain.Entities
{
	public class ProductColors:BaseEntity
	{
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ColorId { get; set; }
        public Color Color { get; set; }
    }
}
