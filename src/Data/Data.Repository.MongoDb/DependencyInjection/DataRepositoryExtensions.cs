namespace UsingMongo.Data.Repository.MongoDb.DependencyInjection
{
	using System;
	using System.Net.Sockets;
	using Microsoft.Extensions.DependencyInjection;
	using MongoDB.Driver;
	using UsingMongo.Data.Repository.MongoDb.Client;
	using UsingMongo.Data.Repository.MongoDb.Mappings;
	using UsingMongo.Data.Repository.MongoDb.Repositories;

	/// <summary>
	/// </summary>
	public static class DataRepositoryExtensions
	{
		/// <summary>
		/// Adds the mongo database.
		/// </summary>
		/// <param name="services">The services.</param>
		/// <param name="configureSettings">The configure settings.</param>
		/// <returns></returns>
		public static IServiceCollection AddMongoDb(this IServiceCollection services, Action<MongoDbSettings> configureSettings)
		{
			var mongoDbSettings = new MongoDbSettings();

			configureSettings(mongoDbSettings);

			services.AddSingleton(mongoDbSettings);

			services.AddMongoClient(mongoDbSettings);

			services.AddSingleton<IMongoDatabaseClient>(serviceProvider =>
			{
				var mongoClient = serviceProvider.GetService<IMongoClient>();
				return new MongoDatabaseClient(mongoClient, mongoDbSettings.DatabaseName);
			});

			services.AddDataRepositories();

			MongoEntityMappings.Map();

			return services;
		}

		/// <summary>
		/// Adds the data repositories.
		/// </summary>
		/// <param name="services">The services.</param>
		/// <returns></returns>
		private static IServiceCollection AddDataRepositories(this IServiceCollection services)
		{
			services.AddScoped<ICustomerRepository, CustomerRepository>();

			return services;
		}

		/// <summary>
		/// Adds the mongo client.
		/// </summary>
		/// <param name="services">The services.</param>
		/// <param name="mongoDbSettings">The mongo database settings.</param>
		/// <returns></returns>
		private static IServiceCollection AddMongoClient(this IServiceCollection services, MongoDbSettings mongoDbSettings)
		{
			services.AddSingleton<IMongoClient>(serviceProvider =>
			{
				void SocketConfigurator(Socket socket) => socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);

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
	}
}