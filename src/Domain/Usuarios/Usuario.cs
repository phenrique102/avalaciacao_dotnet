using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Usuarios
{
    [Table("Usuario")]
    public sealed class Usuario
    {
        [Key]
        public required int IdUsuario { get; init; }
        public required string DsNome { get; init; }
        public required string DsEmail { get; init; }
        public required string DsSenha { get; set; }
        public required string DsSenhaSalt { get; set; }

    }
}
