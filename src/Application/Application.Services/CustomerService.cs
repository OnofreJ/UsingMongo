namespace UsingMongo.Application.Services
{
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using UsingMongo.Application.Dto;
	using UsingMongo.Data.Repository.MongoDb.Repositories;

	internal sealed class CustomerService : ICustomerService
	{
		private readonly ICustomerRepository customerRepository;

		public CustomerService(ICustomerRepository customerRepository)
		{
			this.customerRepository = customerRepository;
		}

		public async Task<Customer> CreateAsync(Customer customer)
		{
			var result = await customerRepository.CreateAsync(new Data.Repository.MongoDb.Model.Customer { Id = customer.Id, Name = customer.Name }).ConfigureAwait(false);

			return new Customer { Id = result.Id, Name = result.Name };
		}

		public Task<IEnumerable<Customer>> CreateAsync(IEnumerable<Customer> customers)
		{
			throw new NotImplementedException();
		}

		public Task<Customer> GetAsync(string id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Customer>> GetAsync()
		{
			throw new NotImplementedException();
		}

		public Task RemoveAllAsync()
		{
			throw new NotImplementedException();
		}

		public Task RemoveAsync(string id)
		{
			throw new NotImplementedException();
		}

		public Task UpdateAsync(Customer customer)
		{
			throw new NotImplementedException();
		}
	}
}