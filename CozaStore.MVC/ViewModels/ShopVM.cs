
using CozaStore.Application.DTOs.ProductDTOs;
using CozaStore.Domain.Entities;

namespace CozaStore.MVC.ViewModels
{
	public class ShopVM
	{
		public IEnumerable<Category> Categories { get; set; }
		public IEnumerable<ProductGetDTO> Products { get; set; }
	}
}
