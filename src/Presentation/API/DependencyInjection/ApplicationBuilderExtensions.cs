namespace UsingMongo.Presentation.API.DependencyInjection
{
	using Microsoft.AspNetCore.Builder;
	using Microsoft.Extensions.DependencyInjection;
	using UsingMongo.Presentation.API.Settings;

	internal static class ApplicationBuilderExtensions
	{
		internal static IApplicationBuilder UseAppServices(this IApplicationBuilder app)
		{
			app.EnableSwagger();

			return app;
		}

		/// <summary>
		/// Enable middleware to serve generated Swagger as a JSON endpoint.
		/// </summary>
		/// <param name="app">The application.</param>
		/// <returns></returns>
		private static IApplicationBuilder EnableSwagger(this IApplicationBuilder app)
		{
			var settings = app.ApplicationServices.GetRequiredService<SwaggerSettings>();

			if (settings.Enable)
			{
				app.UseSwagger();

				app.UseSwaggerUI(setup =>
				{
					setup.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
				});
			}

			return app;
		}
	}
}