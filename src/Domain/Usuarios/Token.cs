namespace Domain.Usuarios
{
    public class Token
    {
        public required string AccessToken { get; set; }
        public required string TokenType { get; set; }
        public required DateTime Expires { get; set; }
    }
}
