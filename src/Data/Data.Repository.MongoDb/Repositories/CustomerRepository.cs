namespace UsingMongo.Data.Repository.MongoDb.Repositories
{
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using MongoDB.Driver;
	using UsingMongo.Data.Repository.MongoDb.Client;
	using UsingMongo.Data.Repository.MongoDb.Model;

	/// <summary>
	/// Represents the class with the implementation to the customer repository.
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

		/// <summary>
		/// Create a single customer in the repository.
		/// </summary>
		/// <param name="customer">The customer.</param>
		public async Task CreateAsync(Customer customer)
		{
			await InsertAsync(customer).ConfigureAwait(false);
		}

		/// <summary>
		/// Gets a single customer from the repository.
		/// </summary>
		/// <param name="id">The customer identifier.</param>
		/// <returns>A <see cref="Customer"/> object.</returns>
		public async Task<Customer> GetAsync(string id)
		{
			var filter = Builders<Customer>.Filter.Eq(field => field.Id, id);

			var result = await FindAsync(filter).ConfigureAwait(false);

			return result.FirstOrDefault();
		}

		/// <summary>
		/// Gets a list of customers from the repository.
		/// </summary>
		/// <returns>A <see cref="IEnumerable{Customer}"/> object.</returns>
		public async Task<IEnumerable<Customer>> GetAsync()
		{
			var filter = Builders<Customer>.Filter.Empty;

			return await FindAsync(filter);
		}

		/// <summary>
		/// Modify a single customer in the repository.
		/// </summary>
		/// <param name="customer">The customer.</param>
		/// <returns>A <see cref="Task"/>.</returns>
		public async Task ModifyAsync(Customer customer)
		{
			var filter = Builders<Customer>.Filter.Eq(field => field.Id, customer.Id);

			await UpdateAsync(filter, customer).ConfigureAwait(false);
		}

		/// <summary>
		/// Remove a single customer in the repository.
		/// </summary>
		/// <param name="id">The customer identifier.</param>
		/// <returns>A <see cref="Task"/>.</returns>
		public async Task RemoveAsync(string id)
		{
			var filter = Builders<Customer>.Filter.Eq(field => field.Id, id);

			await DeleteAsync(filter);
		}
	}
}