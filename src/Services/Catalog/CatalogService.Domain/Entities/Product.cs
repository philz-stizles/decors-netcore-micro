using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace CatalogService.Domain.Entities
{
    public class Product: EntityBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public bool Shipping{ get; set; }
        public int VendorId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Colors { get; set; }
        public string ImageUrl { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
    }
}