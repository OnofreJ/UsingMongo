namespace UsingMongo.Presentation.API
{
	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.Hosting;
	using UsingMongo.Presentation.API.DependencyInjection;
	using UsingMongo.Presentation.API.HttpFilters;

	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		/// <summary>
		/// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		/// </summary>
		/// <param name="app">The application.</param>
		/// <param name="env">The env.</param>
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseAppServices()
				.UseHttpsRedirection()
				.UseRouting()
				.UseAuthorization()
				.UseEndpoints(endpoints => { endpoints.MapControllers(); });
		}

		/// <summary>
		///This method gets called by the runtime. Use this method to add services to the container.
		/// </summary> <param name="services">The services.</param>
		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<ApiBehaviorOptions>(configOptions =>
			{
				configOptions.SuppressModelStateInvalidFilter = true;
			});

			services.AddControllers(options =>
			{
				options.Filters.Add(new ExceptionFilter());
				options.Filters.Add(new ModelStateActionFilter());
			});

			services.InitializeApplicationServices(Configuration);
		}
	}
}