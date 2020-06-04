namespace UsingMongo.Data.Repository.MongoDb.DependencyInjection
{
	using System;
	using System.Net.Sockets;
	using Microsoft.Extensions.DependencyInjection;
	using MongoDB.Driver;
	using UsingMongo.Data.Repository.MongoDb.Mappings;
	using UsingMongo.Data.Repository.MongoDb.Repositories;

	public static class MongoDbExtensions
	{
		public static IServiceCollection AddMongoDb(this IServiceCollection services, Action<MongoDbSettings> configureSettings)
		{
			var mongoDbSettings = new MongoDbSettings();
			configureSettings(mongoDbSettings);
			services.AddSingleton(mongoDbSettings);

			services.AddMongoClient(mongoDbSettings);

			services.AddDataRepositories();

			MongoEntityMappings.Map();

			return services;
		}

		private static IServiceCollection AddDataRepositories(this IServiceCollection services)
		{
			services.AddScoped<ICustomerRepository, CustomerRepository>();

			return services;
		}

		private static IServiceCollection AddMongoClient(this IServiceCollection services, MongoDbSettings mongoDbSettings)
		{
			services.AddSingleton<IMongoClient>(serviceProvider =>
			{
				var mongoClientSettings = MongoClientSettings.FromUrl(new MongoUrl(mongoDbSettings.ConnectionString));

				mongoClientSettings.MaxConnectionIdleTime = TimeSpan.FromSeconds(30);

				mongoClientSettings.ClusterConfigurator = builder =>
				{
					builder.ConfigureTcp(configurator => configurator.With(socketConfigurator: (Action<Socket>)SocketConfigurator));
				};

				var mongoClient = new MongoClient(mongoClientSettings);

				return mongoClient;
			});

			return services;
		}

		private static void SocketConfigurator(Socket socket)
		{
			socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
		}
	}
}