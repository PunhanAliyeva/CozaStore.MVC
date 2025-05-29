using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozaStore.MVC.Domain.Commons
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int? CreatedById { get; set; }

        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedById { get; set; }

        public DateTime? DeletedAt { get; set; }
        public int? DeletedById { get; set; }
    }
}
