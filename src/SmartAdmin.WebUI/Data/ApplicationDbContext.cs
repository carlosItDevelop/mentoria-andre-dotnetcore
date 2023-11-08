using System.Reflection.Emit;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartAdmin.WebUI.Models;

namespace SmartAdmin.WebUI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options){}

        public DbSet<Funcionario> Funcionarios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Funcionario>().HasData(
                        new Funcionario
                        {
                            FuncionarioId = 1,
                            Nome = "Carlos Alberto",
                            Departamento = Departamento.TI,
                            Email = "carlos.itdeveloper@gmail.com"
                        });

            // Configurações adicionais para ApplicationUser
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(e => e.NomeCompleto).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Apelido).IsRequired().HasMaxLength(50);
                entity.Property(e => e.DataDeNascimento).IsRequired().HasColumnType("DateTime");
                // Não é necessário configurar a coluna "Ativo" pois o EF Core inferirá como um campo booleano
            });

            base.OnModelCreating(builder);
        } 

    }
}
