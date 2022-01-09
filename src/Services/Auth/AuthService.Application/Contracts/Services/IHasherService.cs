namespace Auth.Application.Contracts.Services
{
    public interface IHasherService
    {
        string CreateHMACSHA256(string toHash, string key);

        string CreateMD5(string input);

        string CreateMD5Crypto(string input, string key);
    }
}
