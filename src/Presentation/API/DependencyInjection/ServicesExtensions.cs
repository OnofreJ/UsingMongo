namespace UsingMongo.Presentation.API.DependencyInjection
{
	using System;
	using System.Diagnostics.CodeAnalysis;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.OpenApi.Models;
	using UsingMongo.Application.Services.DependencyInjection;
	using UsingMongo.Data.Repository.MongoDb.DependencyInjection;
	using UsingMongo.Infrastructure.CrossCutting.Settings;
	using UsingMongo.Presentation.API.Settings;

	/// <summary>
	/// </summary>
	[ExcludeFromCodeCoverage]
	internal static class ServicesExtensions
	{
		/// <summary>
		/// Initializes the application services.
		/// </summary>
		/// <param name="services">The services.</param>
		/// <param name="configuration">The configuration.</param>
		/// <returns>An <see cref="IServiceCollection"/> object.</returns>
		internal static IServiceCollection InitializeApplicationServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddAppSettings(settings => configuration.Bind("AppSettings", settings))
				.AddApplicationServices()
				.AddSwagger(settings => configuration.Bind("SwaggerSettings", settings))
				.AddMongoDb(settings => configuration.Bind("MongoDbSettings", settings));

			return services;
		}

		/// <summary>
		/// Adds the application settings.
		/// </summary>
		/// <param name="services">The services.</param>
		/// <param name="configureSettings">The configure settings.</param>
		/// <returns>An <see cref="IServiceCollection"/> object.</returns>
		private static IServiceCollection AddAppSettings(this IServiceCollection services, Action<AppSettings> configureSettings)
		{
			services.AddSingleton(serviceProvider =>
			{
				var appSettings = new AppSettings();

				configureSettings(appSettings);

				return appSettings;
			});

			return services;
		}

		/// <summary>
		/// Adds the Swagger.
		/// </summary>
		/// <param name="services">The services.</param>
		/// <param name="configureSettings">The configure settings.</param>
		/// <returns>An <see cref="IServiceCollection"/> object.</returns>
		private static IServiceCollection AddSwagger(this IServiceCollection services, Action<SwaggerSettings> configureSettings)
		{
			var swaggerSettings = new SwaggerSettings();
			configureSettings(swaggerSettings);
			services.AddSingleton(swaggerSettings);

			if (swaggerSettings.Enable)
			{
				services.AddSwaggerGen(options =>
				{
					options.SwaggerDoc("v1", new OpenApiInfo { Title = "UsingMongo Service", Version = "v1" });
				});
			}

			return services;
		}
	}
}