namespace UsingMongo.Data.Repository.MongoDb.Repositories
{
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using MongoDB.Driver;
	using UsingMongo.Data.Repository.MongoDb.Client;
	using UsingMongo.Data.Repository.MongoDb.Model;

	/// <summary>
	/// </summary>
	/// <seealso cref="MongoRepositoryBase{Customer}"/>
	/// <seealso cref="ICustomerRepository"/>
	internal sealed class CustomerRepository : MongoRepositoryBase<Customer>, ICustomerRepository
	{
		/// <summary>
		/// The collection name.
		/// </summary>
		private const string CollectionName = "CustomerCollection";

		/// <summary>
		/// Initializes a new instance of the <see cref="CustomerRepository"/> class.
		/// </summary>
		/// <param name="mongoClient">The mongo client.</param>
		public CustomerRepository(IMongoDatabaseClient mongoClient) : base(mongoClient, CollectionName)
		{
		}

		public async Task CreateAsync(Customer customer)
		{
			await InsertAsync(customer).ConfigureAwait(false);
		}

		public async Task CreateAsync(IEnumerable<Customer> customers)
		{
			await InsertAsync(customers).ConfigureAwait(false);
		}

		public async Task<Customer> GetAsync(string id)
		{
			var filter = Builders<Customer>.Filter.Eq(field => field.Id, id);

			var result = await FindAsync(filter).ConfigureAwait(false);

			return result.FirstOrDefault();
		}

		public async Task<IEnumerable<Customer>> GetAsync()
		{
			var filter = Builders<Customer>.Filter.Empty;

			return await FindAsync(filter);
		}

		public async Task ModifyAsync(Customer customer)
		{
			var filter = Builders<Customer>.Filter.Eq(field => field.Id, customer.Id);

			await UpdateAsync(filter, customer).ConfigureAwait(false);
		}

		public async Task RemoveAsync(string id)
		{
			var filter = Builders<Customer>.Filter.Eq(field => field.Id, id);

			await DeleteAsync(filter);
		}
	}
}