using Cart.Application.Models;
using System.Threading.Tasks;

namespace Cart.Application.Contracts.Services
{
    public interface IUserProfileReader
    {
        Task<UserProfileDto> ReadProfile(string username);
    }
}
