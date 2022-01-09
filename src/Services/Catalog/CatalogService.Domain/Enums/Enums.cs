using System.ComponentModel;

namespace Decors.Domain.Enums
{
    public enum PaymentStatus
    {
        NotPaid = 1,
        Processing,
        Paid,
    }

    public enum TitleType
    {
        Mr = 1,
        Mrs,
        Cheif,
        Dr
    }

    public enum GenderType
    {
        Male = 1,
        Female,
        Cheif,
        Dr
    }


    public enum DocumentType
    {
        UploadId = 1,
        VehicleLicense,
        ProofOfOwnership,
        FleetDetails,
        ApprovedForm,
        InvOfContent,
        DescOfBuilding,
        PoliceReport,
        IncidentFile1,
        IncidentFile2,
        IncidentFile3
    }

    public enum UserStatus
    {
        Admin = 1,
        AdminLead,
        Lead,
        Customer,
        AdminCustomer
    }

    public enum TemplateType
    {
        QuoteCreationNotification = 1,
        PolicyCreationNotification,
        ClaimCreationNotification
    }

    public enum EmailSubscriptionType
    {
        QuoteCreate = 1,
        PolicyCreate,
        Register,
        TransactionCreate,
        ClaimCreate
    }

    public enum ClaimStatusType
    {
        Pending = 1,
        Approved,
        Rejected,
    }

    public enum ActionType
    {
        Pending = 1,
        Approved,
        Rejected,
    }
}
