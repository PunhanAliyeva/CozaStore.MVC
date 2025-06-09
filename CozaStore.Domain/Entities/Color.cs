using CozaStore.Domain.Commons;

namespace CozaStore.Domain.Entities
{
    public class Color:BaseEntity
	{
        public string Name { get; set; }
        public List<ProductColors> ProductColors { get; set; }
    }
}
