using CouponService.API.Entities;
using System.Threading.Tasks;

namespace CouponService.API.Repositories
{
    public interface ICouponRepository
    {
        Task<Coupon> GetDiscount(string productName);

        Task<bool> CreateDiscount(Coupon coupon);
        Task<bool> UpdateDiscount(Coupon coupon);
        Task<bool> DeleteDiscount(string productName);
    }
}
