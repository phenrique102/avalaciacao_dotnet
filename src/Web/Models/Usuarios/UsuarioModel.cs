using System.ComponentModel.DataAnnotations;

namespace Web.Models.Usuarios
{
    public class UsuarioModel
    {
        [Required(ErrorMessage = "Informe o nome")]
        public string? DsNome { get; set; }
        [Required(ErrorMessage = "Informe o e-mail")]
        [EmailAddress]
        public string? DsEmail { get; set; }
        [Required(ErrorMessage = "Informe a senha")]
        public string? DsSenha { get; set; }
        [Required(ErrorMessage = "Informe a confirmação")]
        [Compare(nameof(DsSenha))]
        public string? DsSenhaConfirmacao { get; set; }
    }
}
