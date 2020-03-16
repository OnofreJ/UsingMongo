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
		/// <returns></returns>
		Task CreateAsync(Customer customer);

		/// <summary>
		/// Creates the asynchronous.
		/// </summary>
		/// <param name="customers">The customers.</param>
		/// <returns></returns>
		Task CreateAsync(IEnumerable<Customer> customers);

		/// <summary>
		/// Gets the asynchronous.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		Task<Customer> GetAsync(string id);

		/// <summary>
		/// Gets the asynchronous.
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<Customer>> GetAsync();

		/// <summary>
		/// Modifies the asynchronous.
		/// </summary>
		/// <param name="customer">The customer.</param>
		/// <returns></returns>
		Task ModifyAsync(Customer customer);

		/// <summary>
		/// Removes the asynchronous.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		Task RemoveAsync(string id);
	}
}