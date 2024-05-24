namespace Web.Models
{
    public class LoginResult
    {
        public string? AccessToken { get; set; }
        public string? TokenType { get; set; }
        public string? Expires { get; set; }
        public string? Message { get; set; }
    }
}
