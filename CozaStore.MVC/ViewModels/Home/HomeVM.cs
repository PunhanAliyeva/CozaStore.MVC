using CozaStore.MVC.Models.Entities;

namespace CozaStore.MVC.ViewModels.Home
{
	public class HomeVM
	{
		public IEnumerable<Slider> Sliders { get; set; }
		public IEnumerable<Product> Products { get; set; }
		public IEnumerable<Category> Categories { get; set; }
	}
}
