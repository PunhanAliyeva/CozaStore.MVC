
using CozaStore.MVC.Domain.Commons;

namespace CozaStore.MVC.Entities
{
	public class ProductImage:BaseEntity
	{
        public string ImageUrl { get; set; }
		public bool IsMain { get; set; }
		public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
