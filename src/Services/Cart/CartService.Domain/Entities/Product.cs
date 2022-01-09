using System.Collections.Generic;

namespace Cart.Domain.Entities
{
    public class Product: EntityBase
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public bool Shipping{ get; set; }
        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Colors { get; set; }
        public string ImageUrl { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
    }
}