using Auth.Application.Models;
using System.Threading.Tasks;

namespace Auth.Application.Contracts.Services
{
    public interface IGeoLocationService
    {
        Task<GeoInfoDto> GetGeoInfo();
    }
}
