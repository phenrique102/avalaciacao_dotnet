namespace Domain.Usuarios
{
    public class Usuario : IDominio
    {
        public int IdUsuario { get; init; }
        public required string DsNome { get; init; }
        public required string DsEmail { get; init; }
        public string? DsSenha { get; init; }

        public void Validar()
        {
            ValidatarNome(DsNome);
            ValidatarEmail(DsEmail);
            ValidataSenha(DsSenha);
        }

        private static void ValidatarNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ApplicationException("Prop DsNome é obrigatório");
        }

        private static void ValidatarEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ApplicationException("Prop DsEmail é obrigatório");
        }

        private static void ValidataSenha(string? senha)
        {
            if (!string.IsNullOrEmpty(senha) && senha.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                throw new ApplicationException("A prop senha deve conter ao menos um caractere especial");
            }
        }


    }
}
