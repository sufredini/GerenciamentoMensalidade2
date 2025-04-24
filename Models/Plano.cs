using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciamentoMensalidade2.Models
{
    [Table("Plano")]
    public class Plano
    {
        [Column("Id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("Nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; } = string.Empty;

        [Column("DiasPorSemana")]
        [Display(Name = "DiasPorSemana")]
        public string DiasPorSemana { get; set; } = string.Empty;


    }
}
