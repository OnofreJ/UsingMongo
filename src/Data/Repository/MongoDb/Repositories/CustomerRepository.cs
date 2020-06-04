namespace UsingMongo.Data.Repository.MongoDb.Repositories
{
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using MongoDB.Driver;
	using UsingMongo.Data.Repository.MongoDb.Model;

	/// <summary>
	/// Represents the class that implements the customer repository and interacts with MongoDb.
	/// </summary>
	/// <seealso cref="ICustomerRepository"/>
	internal sealed class CustomerRepository : ICustomerRepository
	{
		private const string CollectionName = "CustomerCollection";

		private readonly IMongoCollection<CustomerCollection> _customerCollection;

		public CustomerRepository(IMongoClient client, MongoDbSettings mongoDbSettings)
		{
			var mongoDbDatabase = client.GetDatabase(mongoDbSettings.DatabaseName);

			_customerCollection = mongoDbDatabase.GetCollection<CustomerCollection>(CollectionName);
		}

		public async Task<string> CreateAsync(CustomerCollection Customer)
		{
			await _customerCollection.InsertOneAsync(Customer).ConfigureAwait(false);

			return Customer.Id;
		}

		public async Task CreateAsync(IEnumerable<CustomerCollection> Customer)
		{
			await _customerCollection.InsertManyAsync(Customer).ConfigureAwait(false);
		}

		public async Task<CustomerCollection> GetAsync(string id)
		{
			var filter = Builders<CustomerCollection>.Filter.Eq(field => field.Id, id);

			var result = await _customerCollection.FindAsync(filter).ConfigureAwait(false);

			return result.FirstOrDefault();
		}

		public async Task<IEnumerable<CustomerCollection>> GetAsync()
		{
			var filter = Builders<CustomerCollection>.Filter.Empty;

			var result = await _customerCollection.FindAsync(filter).ConfigureAwait(false);

			return await result.ToListAsync().ConfigureAwait(false);
		}

		public async Task ModifyAsync(CustomerCollection Customer)
		{
			var filter = Builders<CustomerCollection>.Filter.Eq(field => field.Id, Customer.Id);

			var result = await _customerCollection.ReplaceOneAsync(filter, Customer, new ReplaceOptions { IsUpsert = true }).ConfigureAwait(false);
		}

		public async Task RemoveAsync(string id)
		{
			var filter = Builders<CustomerCollection>.Filter.Eq(field => field.Id, id);

			await _customerCollection.DeleteOneAsync(filter).ConfigureAwait(false);
		}
	}
}