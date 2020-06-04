namespace UsingMongo.Presentation.API
{
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.Hosting;

	public class Program
	{
		public static IHostBuilder CreateHostBuilder(string[] args)
		{
			return Host.CreateDefaultBuilder(args).ConfigureAppConfiguration((hostingContext, config) =>
				{
					config.AddJsonFile("Config/appsettings.json", optional: true, reloadOnChange: true);
				})
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
		}

		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}
	}
}