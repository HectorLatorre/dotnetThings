using firstapp.Models;
using Microsoft.EntityFrameworkCore;

namespace firstapp.Data
{
    public class UniContext : DbContext
    {
        public UniContext(DbContextOptions<UniContext> options) : base(options) { }

        public DbSet<Curso> Cursos { get; set; }
        public DbSet<User> Usuarios { get; set; }
        public DbSet<Inscripcion> Inscripciones { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Curso>().HasKey(r => r.IDCurso);
            modelBuilder.Entity<Curso>().ToTable("Curso");
            modelBuilder.Entity<User>().HasKey(x => x.IDUser);
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Inscripcion>().HasKey(y => y.IDInscripcion);
            modelBuilder.Entity<Inscripcion>().ToTable("Inscripcion");
        }
            
    }
}
