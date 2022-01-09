namespace Cart.Application.Settings
{
    public class JwtSettings
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }

        public string SecretKey { get; set; }

        public int AuthExpiresIn { get; set; }
        public int PasswordResetExpiresIn { get; set; }
    }
}
