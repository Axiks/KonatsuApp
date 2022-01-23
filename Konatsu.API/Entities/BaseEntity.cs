using System;

namespace Konatsu.API.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime? DateUpdated { get; set; }
        public Guid? UserCreated { get; set; }
        public Guid? UserUpdated { get; set; }
    }
}
