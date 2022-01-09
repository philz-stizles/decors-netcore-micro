namespace CatalogService.Application.Contracts.Services.Infrastructure
{
    public interface IUserAccessor
    {
        public string GetCurrentUserId();
        public string GetCurrentEmail();
        public string GetCurrentUserName();
        public string GetCurrentUserIp();
    }
}
