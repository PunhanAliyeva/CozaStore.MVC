
using CozaStore.Domain.Commons;

namespace CozaStore.Domain.Entities
{
    public class Slider:BaseEntity
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ImageUrl { get; set; }
    }
}
