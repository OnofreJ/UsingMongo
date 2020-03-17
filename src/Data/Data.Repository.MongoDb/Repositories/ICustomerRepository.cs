namespace UsingMongo.Data.Repository.MongoDb.Repositories
{
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using Data.Repository.MongoDb.Model;

	/// <summary>
	/// Defines the implementation to the customer repository.
	/// </summary>
	public interface ICustomerRepository
	{
		/// <summary>
		/// Represents the method definition to create a single customer.
		/// </summary>
		/// <param name="customer">The customer.</param>
		/// <returns>A <see cref="Task"/>.</returns>
		Task CreateAsync(Customer customer);

		/// <summary>
		/// Represents the method definition to get a single customer.
		/// </summary>
		/// <param name="id">The customer identifier.</param>
		/// <returns>A <see cref="Customer"/> object.</returns>
		Task<Customer> GetAsync(string id);

		/// <summary>
		/// Represents the method definition to get a list of customers.
		/// </summary>
		/// <returns>A <see cref="IEnumerable{Customer}"/> object.</returns>
		Task<IEnumerable<Customer>> GetAsync();

		/// <summary>
		/// Represents the method definition to modify a single customer.
		/// </summary>
		/// <param name="customer">The customer.</param>
		/// <returns>A <see cref="Task"/>.</returns>
		Task ModifyAsync(Customer customer);

		/// <summary>
		/// Represents the method definition to remove a single customer.
		/// </summary>
		/// <param name="id">The customer identifier.</param>
		/// <returns>A <see cref="Task"/>.</returns>
		Task RemoveAsync(string id);
	}
}