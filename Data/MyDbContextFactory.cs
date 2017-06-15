using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;


namespace firstapp.Data
{
	public class MyDbContextFactory : IDbContextFactory<UniContext>
	{
		public UniContext Create()
		{
			var environmentName =
						Environment.GetEnvironmentVariable(
							"Hosting:Environment");

			var basePath = AppContext.BaseDirectory;

			return Create(basePath, environmentName);
		}

		public MyDbContextFactory Create()
		{
			var optionsBuilder = new DbContextOptionsBuilder<UniContext>();
			optionsBuilder.UseNpgsql("Data Source=blog.db");

            return new MyDbContextFactory(optionsBuilder.Options);
		}

        public UniContext Create(string[] args)
        {
            throw new NotImplementedException();
        }

        private UniContext Create(string basePath, string environmentName)
		{
			var builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
				.SetBasePath(basePath)
				.AddJsonFile("appsettings.json")
				.AddJsonFile($"appsettings.{environmentName}.json", true)
				.AddEnvironmentVariables();

			var config = builder.Build();

			var connstr = config.GetConnectionString("(default)");

			if (String.IsNullOrWhiteSpace(connstr) == true)
			{
				throw new InvalidOperationException(
					"Could not find a connection string named '(default)'.");
			}
			else
			{
				return Create(connstr);
			}
		}

		private UniContext Create(string connectionString)
		{
			if (string.IsNullOrEmpty(connectionString))
				throw new ArgumentException(
					$"{nameof(connectionString)} is null or empty.",
					nameof(connectionString));

			var optionsBuilder =
				new DbContextOptionsBuilder<UniContext>();

			optionsBuilder.UseSqlServer(connectionString);

			return new UniContext(optionsBuilder.Options);
		}
	}
}




