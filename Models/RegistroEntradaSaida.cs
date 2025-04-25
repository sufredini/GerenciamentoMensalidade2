using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace GerenciamentoMensalidade2.Models
{
    [Table("RegistroEntradaSaida")]

    public class RegistroEntradaSaida
    {
        [Column("Id")]
        [Display(Name = "Id")]
        public int RegistroEntradaSaidaId { get; set; }

        [Column("Entrada")]
        [Display(Name = "Entrada")]
        public string Entrada { get; set; } = string.Empty;


        [Column("Saida")]
        [Display(Name = "Saída")]
        public string Saida { get; set; } = string.Empty;

    }
}