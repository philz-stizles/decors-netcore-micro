using Auth.Domain.Entities;
using System.Collections.Generic;

namespace Auth.Application.Contracts.Services
{
    public interface IJwtService
    {
        public string CreateToken(User user, IList<string> roles);
    }
}
