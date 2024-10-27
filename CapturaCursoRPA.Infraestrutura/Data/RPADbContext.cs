using CapturaCursoRPA.Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace CapturaCursoRPA.Infraestrutura.Data
{
    public class RPADbContext : DbContext
    {
        public RPADbContext(DbContextOptions<RPADbContext> options) : base(options) 
        {
            //Database.EnsureCreated();
        }

        public DbSet<Curso> Cursos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definir chave primária de id único
            modelBuilder.Entity<Curso>().HasKey(p => p.IdCaptura);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=automacao.db");
            }
        }
    }
}
