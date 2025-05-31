
using CozaStore.MVC.Domain.Commons;
using CozaStore.MVC.Domain.Entities;

namespace CozaStore.MVC.Entities
{
	public class Tag:BaseEntity
	{
        public string Name { get; set; }
		public List<ProductTags> ProductTags { get; set; }
	}
}
