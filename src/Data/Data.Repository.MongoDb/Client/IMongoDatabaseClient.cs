namespace UsingMongo.Data.Repository.MongoDb.Client
{
	using MongoDB.Driver;

	public interface IMongoDatabaseClient
	{
		IMongoDatabase CreateDatabase();
	}
}