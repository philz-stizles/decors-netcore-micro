using Cart.Domain.Entities;
using System.Collections.Generic;

namespace Cart.Application.Contracts.Services
{
    public interface IJwtService
    {
        public string CreateToken(User user, IList<string> roles);
    }
}
