using CouponService.API.Entities;
using System.Threading.Tasks;

namespace CouponService.API.Repositories
{
    public class CouponRepository : ICouponRepository
    {
        public Task<bool> CreateDiscount(Coupon coupon)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteDiscount(string productName)
        {
            throw new System.NotImplementedException();
        }

        public Task<Coupon> GetDiscount(string productName)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateDiscount(Coupon coupon)
        {
            throw new System.NotImplementedException();
        }
    }
}
