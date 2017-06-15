using System;
using System.Linq;
using firstapp.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessPostgreSqlProvider
{
	// >dotnet ef migration add testMigration in AspNet5MultipleProject
	public class DomainModelPostgreSqlContext : DbContext
	{
		public DomainModelPostgreSqlContext(DbContextOptions<DomainModelPostgreSqlContext> options) : base(options)
		{
		}

		public DbSet<Curso> Cursos { get; set; }
		public DbSet<User> Usuarios { get; set; }
		public DbSet<Inscripcion> Inscripciones { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Curso>().HasKey(m => m.IDCurso);
            modelBuilder.Entity<User>().HasKey(m => m.IDUser);
            modelBuilder.Entity<Inscripcion>().HasKey(mx => mx.IDInscripcion);
			base.OnModelCreating(modelBuilder);
		}

		public override int SaveChanges()
		{
			ChangeTracker.DetectChanges();

			updateUpdatedProperty<Curso>();
			updateUpdatedProperty<User>();
            updateUpdatedProperty<Inscripcion>();

			return base.SaveChanges();
		}

		private void updateUpdatedProperty<T>() where T : class
		{
			var modifiedSourceInfo =
				ChangeTracker.Entries<T>()
					.Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

			foreach (var entry in modifiedSourceInfo)
			{
				entry.Property("UpdatedTimestamp").CurrentValue = DateTime.UtcNow;
			}
		}
	}
}