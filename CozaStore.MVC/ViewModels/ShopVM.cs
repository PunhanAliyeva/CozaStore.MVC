using CozaStore.MVC.Entities;

namespace CozaStore.MVC.ViewModels
{
	public class ShopVM
	{
		public IEnumerable<Category> Categories { get; set; }
		public IEnumerable<Product> Products { get; set; }
	}
}
