namespace Cart.Domain.Entities
{
    public class CustomerCartItem
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductColor { get; set; }
        public string ProductCategory { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
