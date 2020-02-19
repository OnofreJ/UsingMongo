namespace UsingMongo.Presentation.Api.DependencyInjection
{
	using Microsoft.AspNetCore.Builder;
	using Microsoft.Extensions.DependencyInjection;
	using UsingMongo.Presentation.Api.Swagger;

	internal static class ApplicationBuilderExtensions
	{
		internal static IApplicationBuilder UseAppServices(this IApplicationBuilder app)
		{
			app.UseSwagger();

			return app;
		}

		private static IApplicationBuilder UseSwagger(this IApplicationBuilder app)
		{
			var settings = app.ApplicationServices.GetRequiredService<SwaggerSettings>();

			if (settings.Enable)
			{
				SwaggerBuilderExtensions.UseSwagger(app);

				app.UseSwaggerUI(setup =>
				{
					const string url = "/swagger/v1/swagger.json";
					setup.SwaggerEndpoint(url, "UsingMongo Service API V1.0");
				});
			}

			return app;
		}
	}
}