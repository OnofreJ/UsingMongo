namespace UsingMongo.Data.Repository.MongoDb.Repositories
{
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using Data.Repository.MongoDb.Model;

	public interface ICustomerRepository
	{
		Task<Customer> CreateAsync(Customer customer);

		Task<IEnumerable<Customer>> CreateAsync(IEnumerable<Customer> customers);

		Task<Customer> GetAsync(string id);

		Task<IEnumerable<Customer>> GetAsync();

		Task RemoveAllAsync();

		Task RemoveAsync(string id);

		Task UpdateAsync(Customer customer);
	}
}