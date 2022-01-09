using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Auth.Domain.Entities
{
    public class Role: IdentityRole<Guid>
    {
        public virtual ICollection<RolePermission> Permissions { get; set; }
    }
}
