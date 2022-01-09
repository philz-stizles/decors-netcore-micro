using System.Collections.Generic;

namespace Cart.Application.Models
{
    public class RoleDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Permissions { get; set; }
    }
}
