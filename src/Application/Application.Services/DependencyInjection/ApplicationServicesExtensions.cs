namespace UsingMongo.Application.Services.DependencyInjection
{
	using Microsoft.Extensions.DependencyInjection;

	public static class ApplicationServicesExtensions
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			services.AddScoped<ICustomerService, CustomerService>();

			return services;
		}
	}
}