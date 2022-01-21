using System.Collections.Generic;

namespace CartService.Application.Models.Dtos
{
    public class CartSaveDto
    {
        public string Id { get; set; } // This will be generated from the client-side
        public List<CartItemDto> Items { get; set; } = new List<CartItemDto>();
        public int? DeliveryMethodId { get; set; }
        public string ClientSecret { get; set; }
        public string PaymentIntentId { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalAfterDiscount { get; set; }
    }

    public class CartDto
    {
        public CartDto(string id)
        {
            Id = id;
        }

        public string Id { get; set; } // This will be generated from the client-side
        public List<CartItemDto> Items { get; set; } = new List<CartItemDto>();
        public int? DeliveryMethodId { get; set; }
        public string ClientSecret { get; set; }
        public string PaymentIntentId { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalAfterDiscount { get; set; }
    }
}