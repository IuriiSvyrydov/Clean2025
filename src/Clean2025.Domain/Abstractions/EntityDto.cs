using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clean2025.Domain.Abstractions
{
    public abstract class EntityDto
    {
         public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}