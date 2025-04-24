using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciamentoMensalidade2.Models
{
    [Table("Alunos")]
    public class Alunos
    {
        [Column("Id")]
        [Display(Name = "Id do Aluno")]
        public int Id { get; set; }

        [Column("Nome")]
        [Display(Name = "Nome do aluno")]
        public string Nome { get; set; } = string.Empty;

        [Column("Cpf")]
        [Display(Name = "Cpf do aluno")]
        public string Cpf { get; set; } = string.Empty;

        [Column("Telefone")]
        [Display(Name = "Telefone do aluno")]
        public string Telefone { get; set; } = string.Empty;

        [ForeignKey("PlanoId")]
        [Display(Name = "Plano")]
        public int PlanoId { get; set; }
        public Plano? Plano { get; set; }

        [Column("Status")]
        [Display(Name = "Status do Aluno")]
        public string Status { get; set; } = string.Empty;
    }
}
