
using CozaStore.Application.DTOs.ProductDTOs;
using CozaStore.Domain.Entities;

namespace CozaStore.MVC.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Slider> Sliders { get; set; }
        public IEnumerable<ProductGetDTO> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
