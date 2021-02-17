using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using CrudApp.Models;

namespace CrudApp.Data
{
    public class ApplicationDatabase : DbContext
    {
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Estado> Estado { get; set; }

        public ApplicationDatabase (DbContextOptions<ApplicationDatabase> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estado>()
                .HasIndex(estado => estado.Sigla)
                .IsUnique();

            modelBuilder.Entity<Estado>()
                .Property(estado => estado.Sigla)
                .IsRequired();

            modelBuilder.Entity<Estado>()
                .Property(estado => estado.Nome)
                .IsRequired();

            modelBuilder.Entity<Funcionario>()
                .Property(functionario => functionario.Nome)
                .IsRequired();

            modelBuilder.Entity<Funcionario>()
                .Property(functionario => functionario.Email)
                .IsRequired();

            modelBuilder.Entity<Funcionario>()
                .Property(functionario => functionario.DataNascimento)
                .IsRequired();

            modelBuilder.Entity<Funcionario>()
                .Property(functionario => functionario.Salario)
                .HasPrecision(18, 2)
                .IsRequired(false);

            modelBuilder.Entity<Funcionario>()
                .HasOne(funcionario => funcionario.Estado)
                .WithOne()
                .HasForeignKey(nameof(Funcionario), "FK_Estado")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
