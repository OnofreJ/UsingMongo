using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace UsingMongo.Data.Repository.MongoDb.Client
{
	internal abstract class MongoRepositoryBase<T> where T : class, new()
	{
		protected readonly IMongoDatabase MongoDatabase;
		private readonly string MongoCollectionName;

		public MongoRepositoryBase(IMongoDatabaseClient mongoDatabaseClient, string mongoCollectionName)
		{
			MongoCollectionName = mongoCollectionName;
			MongoDatabase = mongoDatabaseClient.CreateDatabase();
		}

		protected internal virtual async Task<long> DeleteAsync(FilterDefinition<T> filter)
		{
			var result = await MongoDatabase
				.GetCollection<T>(MongoCollectionName)
				.DeleteManyAsync(filter);

			return result.DeletedCount;
		}

		protected internal virtual async Task<T> FindAsync(FilterDefinition<T> filter)
		{
			var result = await MongoDatabase
				.GetCollection<T>(MongoCollectionName)
				.Find(filter)
				.Limit(1)
				.FirstOrDefaultAsync();

			return result;
		}

		protected internal virtual async Task<IEnumerable<T>> GetAsync()
		{
			var result = await MongoDatabase
				.GetCollection<T>(MongoCollectionName)
				.Find(filter => true)
				.ToListAsync();

			return result;
		}

		protected internal virtual async Task<IEnumerable<T>> GetAsync(FilterDefinition<T> filter)
		{
			var result = await MongoDatabase
				.GetCollection<T>(MongoCollectionName)
				.Find(filter)
				.ToListAsync();

			return result;
		}

		protected internal virtual async Task<BsonDocument> GetAsync(FilterDefinition<T> filter, ProjectionDefinition<T> projection)
		{
			var result = await MongoDatabase
				.GetCollection<T>(MongoCollectionName)
				.Find(filter)
				.Project(projection)
				.SingleOrDefaultAsync();

			return result;
		}

		protected internal virtual async Task<T> InsertAsync(T value)
		{
			await MongoDatabase
				.GetCollection<T>(MongoCollectionName)
				.InsertOneAsync(value);

			return value;
		}

		protected internal virtual async Task<IEnumerable<T>> InsertAsync(IEnumerable<T> values)
		{
			await MongoDatabase
				.GetCollection<T>(MongoCollectionName)
				.InsertManyAsync(values);

			return values;
		}

		protected internal virtual async Task UpdatePropertyAsync(FilterDefinition<T> filter, UpdateDefinition<T> update)
		{
			var options = new UpdateOptions
			{
				IsUpsert = true
			};

			await MongoDatabase
				.GetCollection<T>(MongoCollectionName)
				.UpdateOneAsync(filter, update, options);
		}
	}
}