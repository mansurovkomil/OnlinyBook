namespace OnlinyBook.Configurations.LayerConfigurations
{
	public static class WebConfiguration
	{
		public static void ConfigurWeb(this IServiceCollection services, IConfiguration configuration)
		{
			services.ConfigureAuth(configuration);
		}
	}
}
