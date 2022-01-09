namespace Cart.Domain.Enums
{
    public enum TransactionStatus
    {
        Start = 1,
        Pending,
        Processing,
        Successful,
        Failed,
        Reversed
    }
}
