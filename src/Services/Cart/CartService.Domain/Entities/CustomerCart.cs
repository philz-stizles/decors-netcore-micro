using System.Collections.Generic;

namespace Cart.Domain.Entities
{
    public class CustomerCart
    {
        public CustomerCart()
        {
        }

        public CustomerCart(string id)
        {
            Id = id;
        }

        public string Id { get; set; } // This will be generated from the client-side
        public decimal TotalAmount { get; set; }
        public decimal TotalAfterDiscount { get; set; }
        public List<CustomerCartItem> Items { get; set; } = new List<CustomerCartItem>();
    }
}
