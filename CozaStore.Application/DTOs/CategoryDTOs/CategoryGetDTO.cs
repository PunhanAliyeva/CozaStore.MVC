
namespace CozaStore.MVC.Application.DTOs.CategoryDTOs
{
    public class CategoryGetDTO
    {
        public string Name { get; set; }
        public string Concept { get; set; }
        public string ImageUrl { get; set; }
        public int? ParentId { get; set; }
        public string ParentName { get; set; }
    }
}
