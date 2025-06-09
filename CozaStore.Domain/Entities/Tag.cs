
using CozaStore.Domain.Commons;
using CozaStore.Domain.Entities;

namespace CozaStore.Domain.Entities
{
	public class Tag:BaseEntity
	{
        public string Name { get; set; }
		public List<ProductTags> ProductTags { get; set; }
	}
}
