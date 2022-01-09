using Cart.Application.Models;
using System.Threading.Tasks;

namespace Cart.Application.Contracts.Services
{
    public interface IGeoLocationService
    {
        Task<GeoInfoDto> GetGeoInfo();
    }
}
