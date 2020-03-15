namespace UsingMongo.Application.Services.DependencyInjection
{
	using Microsoft.Extensions.DependencyInjection;
	using UsingMongo.Application.Services.Mappers;

	public static class ApplicationServicesExtensions
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			services.AddScoped<ICustomerService, CustomerService>();
			services.AddScoped<ICustomerServiceMapper, CustomerServiceMapper>();

			return services;
		}
	}
}