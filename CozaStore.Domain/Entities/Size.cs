
using CozaStore.Domain.Commons;

namespace CozaStore.Domain.Entities
{
	public class Size:BaseEntity
	{
        public string Name { get; set; }
        public List<ProductSizes> ProductSizes { get; set; }
    }
}
