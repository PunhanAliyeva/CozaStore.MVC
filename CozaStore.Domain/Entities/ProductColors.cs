
using CozaStore.MVC.Domain.Commons;

namespace CozaStore.MVC.Models.Entities
{
	public class ProductColors:BaseEntity
	{
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ColorId { get; set; }
        public Color Color { get; set; }
    }
}
