
using CozaStore.MVC.Domain.Commons;
using CozaStore.MVC.Entities;

namespace CozaStore.MVC.Domain.Entities
{
	public class ProductTags:BaseEntity
	{
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
