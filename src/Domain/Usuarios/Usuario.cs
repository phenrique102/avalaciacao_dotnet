namespace Domain.Usuarios
{
    public sealed class Usuario
    {
        public required int IdUsuario { get; init; }
        public required string DsNome { get; init; }
        public required string DsEmail { get; init; }
        public string? DsSenha { get; init; }

    }
}
