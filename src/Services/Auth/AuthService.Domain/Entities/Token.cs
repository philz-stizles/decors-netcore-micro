using System;

namespace Auth.Domain.Entities
{
    public class Token: EntityBase
    {
        public string Value { get; set; }
        public DateTime ExpiresAt { get; set; }
        public User User { get; set; }
    }
}
