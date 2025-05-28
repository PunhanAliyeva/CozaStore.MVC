using CozaStore.MVC.Domain.Commons;

namespace CozaStore.MVC.Models.Entities
{
    public class Color:BaseEntity
	{
        public string Name { get; set; }
        public List<ProductColors> ProductColors { get; set; }
    }
}
