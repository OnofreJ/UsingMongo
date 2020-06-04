namespace UsingMongo.Data.Repository.MongoDb.Repositories
{
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using Data.Repository.MongoDb.Model;

	/// <summary>
	/// </summary>
	public interface ICustomerRepository
	{
		/// <summary>
		/// Creates the asynchronous.
		/// </summary>
		/// <param name="customer">The customer.</param>
		/// <returns>A <see cref="string"/> object.</returns>
		Task<string> CreateAsync(CustomerCollection customer);

		/// <summary>
		/// Creates the asynchronous.
		/// </summary>
		/// <param name="customers">The customers.</param>
		/// <returns>A <see cref="Task"/> object.</returns>
		Task CreateAsync(IEnumerable<CustomerCollection> customers);

		/// <summary>
		/// Gets the asynchronous.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>A <see cref="CustomerCollection"/> object.</returns>
		Task<CustomerCollection> GetAsync(string id);

		/// <summary>
		/// Gets the asynchronous.
		/// </summary>
		/// <returns>An <see cref="IEnumerable{CustomerCollection}"/> object.</returns>
		Task<IEnumerable<CustomerCollection>> GetAsync();

		/// <summary>
		/// Modifies the asynchronous.
		/// </summary>
		/// <param name="customer">The customer.</param>
		/// <returns>A <see cref="Task"/> object.</returns>
		Task ModifyAsync(CustomerCollection customer);

		/// <summary>
		/// Removes the asynchronous.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>A <see cref="Task"/> object.</returns>
		Task RemoveAsync(string id);
	}
}