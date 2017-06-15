using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using firstapp;

namespace firstapp
{
	public class ContextFactory : IDbContextFactory<DomainModelPostgreSqlContext>
	{
		public BloggingContext Create()
		{
			var optionsBuilder = new DbContextOptionsBuilder<BloggingContext>();
			optionsBuilder.UseSqlite("Filename=./blog.db");

			return new BloggingContext(optionsBuilder.Options);
		}
	}
}