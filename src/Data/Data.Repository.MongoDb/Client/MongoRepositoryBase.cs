namespace UsingMongo.Data.Repository.MongoDb.Client
{
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using MongoDB.Driver;

	/// <summary>
	/// </summary>
	/// <typeparam name="T"></typeparam>
	internal abstract class MongoRepositoryBase<T> where T : class, new()
	{
		private readonly IMongoCollection<T> mongoCollection;
		private readonly IMongoDatabase mongoDatabase;

		/// <summary>
		/// Initializes a new instance of the <see cref="MongoRepositoryBase{T}"/> class.
		/// </summary>
		/// <param name="mongoDatabaseClient">The mongo database client.</param>
		/// <param name="mongoCollectionName">Name of the mongo collection.</param>
		public MongoRepositoryBase(IMongoDatabaseClient mongoDatabaseClient, string mongoCollectionName)
		{
			mongoDatabase = mongoDatabaseClient.CreateDatabase();
			mongoCollection = mongoDatabase.GetCollection<T>(mongoCollectionName);
		}

		/// <summary>
		/// Deletes the asynchronous.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <returns></returns>
		protected internal virtual async Task<long> DeleteAsync(FilterDefinition<T> filter)
		{
			var result = await mongoCollection.DeleteOneAsync(filter).ConfigureAwait(false);

			return result.DeletedCount;
		}

		/// <summary>
		/// Finds the asynchronous.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <returns></returns>
		protected internal virtual async Task<IEnumerable<T>> FindAsync(FilterDefinition<T> filter)
		{
			var result = await mongoCollection.Find(filter).ToListAsync().ConfigureAwait(false);

			return result;
		}

		/// <summary>
		/// Inserts the asynchronous.
		/// </summary>
		/// <param name="value">The value.</param>
		protected internal virtual async Task InsertAsync(T value)
		{
			await mongoCollection.InsertOneAsync(value).ConfigureAwait(false);
		}

		/// <summary>
		/// Inserts the asynchronous.
		/// </summary>
		/// <param name="values">The values.</param>
		protected internal virtual async Task InsertAsync(IEnumerable<T> values)
		{
			await mongoCollection.InsertManyAsync(values).ConfigureAwait(false);
		}

		/// <summary>
		/// Updates the asynchronous.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <param name="value">The value.</param>
		protected internal virtual async Task UpdateAsync(FilterDefinition<T> filter, T value)
		{
			await mongoCollection.ReplaceOneAsync(filter, value, new ReplaceOptions { IsUpsert = true });
		}
	}
}