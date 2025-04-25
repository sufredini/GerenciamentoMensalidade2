using GerenciamentoMensalidade2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoMensalidade2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Plano> Plano { get; set; }
        public DbSet<Alunos> Alunos { get; set; }
        public DbSet<Pagamento> Pagamento { get; set; }
        public DbSet<Administrador> Administrador { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Alunos>().ToTable("Alunos");
            builder.Entity<Plano>().ToTable("Planos");
            builder.Entity<Pagamento>().ToTable("Pagamento");
            builder.Entity<Administrador>().ToTable("Administrador");
        }
    }
}