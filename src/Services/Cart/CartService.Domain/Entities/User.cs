using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Cart.Domain.Entities
{
    public class User: IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
    }
}
