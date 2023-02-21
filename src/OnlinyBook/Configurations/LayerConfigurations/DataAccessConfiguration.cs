using Microsoft.EntityFrameworkCore;
using OnlinyBook.DataAccess.DbContexts;
using OnlinyBook.DataAccess.Interfaces;
using OnlinyBook.DataAccess.Repositories;

namespace OnlinyBook.Configurations.LayerConfigurations
{
	public static class DataAccessConfiguration
	{
		public static void AddDataAccess(this IServiceCollection services, IConfiguration configuration)
		{
			string connectionString = configuration.GetConnectionString("DatabaseConnection")!;
			services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
			services.AddScoped<IUnitOfWork, UnitOfWork>();
		}

	}
}
