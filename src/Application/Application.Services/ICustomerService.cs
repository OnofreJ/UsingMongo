namespace UsingMongo.Application.Services
{
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using UsingMongo.Application.Dto;

	public interface ICustomerService
	{
		Task CreateAsync(Customer customer);

		Task CreateAsync(IEnumerable<Customer> customers);

		Task<Customer> GetAsync(string id);

		Task<IEnumerable<Customer>> GetAsync();

		Task RemoveAllAsync();

		Task RemoveAsync(string id);

		Task ModifyAsync(Customer customer);
	}
}