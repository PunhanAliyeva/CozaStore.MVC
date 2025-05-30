using CozaStore.MVC.Entities;

namespace CozaStore.MVC.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Slider> Sliders { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
