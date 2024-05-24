using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Informe o e-mail")]
        [EmailAddress]
        public string? DsEmail { get; set; }
        [Required(ErrorMessage = "Informe a senha")]
        public string? DsSenha { get; set; }
    }
}
