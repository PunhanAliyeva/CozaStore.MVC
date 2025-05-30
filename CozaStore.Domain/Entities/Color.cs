using CozaStore.MVC.Domain.Commons;

namespace CozaStore.MVC.Entities
{
    public class Color:BaseEntity
	{
        public string Name { get; set; }
        public List<ProductColors> ProductColors { get; set; }
    }
}
