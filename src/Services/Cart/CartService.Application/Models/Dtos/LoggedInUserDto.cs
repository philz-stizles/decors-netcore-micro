using System.Collections.Generic;

namespace Cart.Application.Models
{
    public class LoggedInUserDto
    {
        public string Token { get; set; }
        public UserDto UserDetails { get; set; }
        public IList<string> Roles { get; set; }
    }

    public class UserDto
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Avatar { get; set; }
    }
}
