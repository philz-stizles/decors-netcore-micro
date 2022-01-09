using System;

namespace Cart.Domain.Entities
{
    public class Coupon: EntityBase
    {
        public string Code { get; set; }
        public int Discount { get; set; }
        public bool IsActive { get; set; }
        public DateTime Expires { get; set; }
        public int VendorId { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
