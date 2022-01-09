namespace CatalogService.Application.Models.Requests
{
    public class CreateProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
        public bool Shipping { get; set; }
        public string VendorId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
