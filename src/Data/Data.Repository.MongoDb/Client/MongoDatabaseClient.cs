namespace UsingMongo.Data.Repository.MongoDb.Client
{
	using MongoDB.Driver;

	/// <summary>
	/// </summary>
	/// <seealso cref="UsingMongo.Data.Repository.MongoDb.Client.IMongoDatabaseClient"/>
	public class MongoDatabaseClient : IMongoDatabaseClient
	{
		protected readonly string mongoDatabaseName;

		/// <summary>
		/// Initializes a new instance of the <see cref="MongoDatabaseClient"/> class.
		/// </summary>
		/// <param name="mongoClient">The mongo client.</param>
		/// <param name="mongoDatabaseName">Name of the mongo database.</param>
		public MongoDatabaseClient(IMongoClient mongoClient, string mongoDatabaseName)
		{
			MongoClient = mongoClient;
			this.mongoDatabaseName = mongoDatabaseName;
		}

		/// <summary>
		/// Gets the mongo client.
		/// </summary>
		/// <value>The mongo client.</value>
		protected IMongoClient MongoClient { get; }

		/// <summary>
		/// Creates the database.
		/// </summary>
		/// <returns></returns>
		public IMongoDatabase CreateDatabase()
		{
			return MongoClient.GetDatabase(mongoDatabaseName);
		}
	}
}