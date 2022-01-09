using System;

namespace Auth.Domain.Entities
{
    public class RolePermission
    {
        public Permission Permission { get; set; }
        public int PermissionId { get; set; }

        public Role Role { get; set; }
        public Guid RoleId { get; set; }
    }
}
