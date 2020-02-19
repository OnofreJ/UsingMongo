namespace UsingMongo.Presentation.Api
{
	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.AspNetCore.Http;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Mvc.Infrastructure;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.DependencyInjection.Extensions;
	using UsingMongo.Presentation.Api.DependencyInjection;

	internal class Startup
	{
		private readonly IConfiguration configuration;

		/// <summary>
		/// Initializes a new instance of the <see cref="Startup"/> class.
		/// </summary>
		/// <param name="configuration">The configuration.</param>
		public Startup(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		/// <summary>
		/// Configures the HTTP request pipeline.
		/// </summary>
		/// <param name="app">The application.</param>
		/// <param name="env">The env.</param>
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection()
				.UseMvc()
				.UseAppServices();
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		/// <summary>
		/// Configures the services.
		/// </summary>
		/// <param name="services">The services.</param>
		public void ConfigureServices(IServiceCollection services)
		{
			// on linux systems this injection needs to be done explicitly
			services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			services.InitializeServices(configuration);
		}
	}
}