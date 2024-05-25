using System.ComponentModel.DataAnnotations;

namespace Web.Models.Planos
{
    public class PlanoModel
    {
        public int IdPlano { get; set; }
        [Required]
        public string NoPlano { get; set; }
        public string DsPlano { get; set; }
    }
}
