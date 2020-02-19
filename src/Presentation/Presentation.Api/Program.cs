namespace UsingMongo.Presentation.Api
{
	using System.IO;
	using System.Net;
	using Microsoft.AspNetCore;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.Extensions.Configuration;

	public class Program
    {
        /// <summary>
        /// The service port.
        /// </summary>
        private const int ServicePort = 5001;

        /// <summary>
        /// Creates the web host builder.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseDefaultServiceProvider((context, options) =>
                {
                    options.ValidateScopes = true;
                })
                .ConfigureAppConfiguration((context, builder) =>
                {
                    var environment = context.HostingEnvironment;

                    builder.SetBasePath(environment.ContentRootPath)
                        .AddJsonFile("conf/appsettings.json", optional: false, reloadOnChange: true)
                        .AddJsonFile($"conf/appsettings.{environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                        .AddEnvironmentVariables();
                })
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseKestrel(options =>
                {
                    options.AddServerHeader = false;
                    options.Listen(IPAddress.Any, ServicePort);
                })
                .UseStartup<Startup>();

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }
    }
}