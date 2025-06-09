
namespace CozaStore.Application.DTOs.CategoryDTOs
{
	public class CategoryGetDTO
	{
        public int Id { get; set; }
        public string Name { get; set; }
		public string Concept { get; set; }
		public string ImageUrl { get; set; }
		public int? ParentId { get; set; }
		public string ParentName { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? ModifiedAt { get; set; }
		public DateTime? DeletedAt { get; set; }
	}
}
