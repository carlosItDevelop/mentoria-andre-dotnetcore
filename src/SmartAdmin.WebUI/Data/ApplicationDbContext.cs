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

            base.OnModelCreating(builder);
        } 

    }
}
