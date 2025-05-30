
using CozaStore.MVC.Domain.Commons;

namespace CozaStore.MVC.Entities
{
	public class Size:BaseEntity
	{
        public string Name { get; set; }
        public List<ProductSizes> ProductSizes { get; set; }
    }
}
