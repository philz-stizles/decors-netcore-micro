namespace Auth.Domain.Entities
{
    public class Document: EntityBase
    {
        public bool IsMain { get; set; }
        public string Url { get; set; }
    }
}
