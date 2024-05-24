namespace Application.Usuarios.Queries.LoginComCredenciais
{
    public class LoginComCredenciaisOutputModel
    {
        public required string AccessToken { get; set; }
        public required string TokenType { get; set; }
        public required DateTime Expires { get; set; }
    }
}
