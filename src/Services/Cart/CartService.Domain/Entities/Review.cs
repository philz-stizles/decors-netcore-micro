namespace Cart.Domain.Entities
{
    public class Review: EntityBase
    {
        public string Comment { get; set; }

        public int Rating { get; set; }
        public virtual User User { get; set; }
    }
}
