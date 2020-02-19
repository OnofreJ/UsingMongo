namespace UsingMongo.Data.Repository.MongoDb.Client
{
	using MongoDB.Driver;

	public class MongoDatabaseClient : IMongoDatabaseClient
	{
		protected readonly string mongoDatabaseName;

		public MongoDatabaseClient(IMongoClient mongoClient, string mongoDatabaseName)
		{
			MongoClient = mongoClient;
			this.mongoDatabaseName = mongoDatabaseName;
		}

		protected IMongoClient MongoClient { get; }

		public IMongoDatabase CreateDatabase()
		{
			return MongoClient.GetDatabase(mongoDatabaseName);
		}

		public void DropDatabase()
		{
			MongoClient.DropDatabase(mongoDatabaseName);
		}
	}
}
