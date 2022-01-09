namespace Auth.Domain.Entities
{
    public class Photo: EntityBase
    {
        public bool IsMain { get; set; }
        public string Url { get; set; }
    }
}
