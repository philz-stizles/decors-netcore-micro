using System.Collections.Generic;

namespace Auth.Domain.Entities
{
    public class Permission: EntityBase
    {
        public virtual ICollection<RolePermission> Roles { get; set; }
    }
}
