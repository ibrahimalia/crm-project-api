namespace Meta.IntroApp.DTOs.JWT
{
    public class TokenDTO
    {
        public string AccessToken { get; set; }
        public int ExpiresIn { get; set; }
        public string RefreshToken { get; set; }
    }
}