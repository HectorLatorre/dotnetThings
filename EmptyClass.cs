using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using firstapp.Data;

namespace firstapp
{
	public class BloggingContextFactory : IDbContextFactory<UniContext>
	{
		public BloggingContext Create()
		{
			var optionsBuilder = new DbContextOptionsBuilder<UniContext>();
			optionsBuilder.UseSqlite("Data Source=blog.db");

			return new BloggingContext(optionsBuilder.Options);
		}
	}
}