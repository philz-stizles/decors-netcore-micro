using System.Runtime.Serialization;

namespace Decors.Domain.Enums
{
    public enum OrderStatus
    {
        [EnumMember(Value ="Pending")]
        Pending = 1,
        [EnumMember(Value ="Processing")]
        Processing,
        [EnumMember(Value ="Dispatched")]
        Dispatched,
        [EnumMember(Value ="Cancelled")]
        Cancelled,
        [EnumMember(Value ="Payment Received")]
        PaymentReceived,
        [EnumMember(Value ="Payment Failed")]
        PaymentFailed,
        [EnumMember(Value ="Completed")]
        Completed
    }
}
