using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciamentoMensalidade.Models
{
    [Table("Pagamentos")]
    public class Pagamento
    {
        [Column("Id")]
        [Display(Name = "PagamentoId")]
        public int Id { get; set; }

        [ForeignKey("ALunosId")]
        [Display(Name = "Id do Aluno")]
        public int AlunosId { get; set; }
        public Alunos? Alunos { get; set; }

        [Column("DataPagamento")]
        [Display(Name = "DtPagamento")]
        public string DtPagamento { get; set; } = string.Empty;
    }
}