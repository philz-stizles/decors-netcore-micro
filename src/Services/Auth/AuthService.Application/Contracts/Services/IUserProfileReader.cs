using Auth.Application.Models;
using System.Threading.Tasks;

namespace Auth.Application.Contracts.Services
{
    public interface IUserProfileReader
    {
        Task<UserProfileDto> ReadProfile(string username);
    }
}
