namespace JobTracking.Domain.Constants
{
    public static class Jwt
    {
        public static string Key => $"{nameof(Jwt)}:{nameof(Key)}";
        public static string Issuer => $"{nameof(Jwt)}:{nameof(Issuer)}";
        public static string Audience => $"{nameof(Jwt)}:{nameof(Audience)}";
    }
}
