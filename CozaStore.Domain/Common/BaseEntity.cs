﻿namespace CozaStore.Domain.Commons
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
