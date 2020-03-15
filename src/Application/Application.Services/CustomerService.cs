namespace UsingMongo.Application.Services
{
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using UsingMongo.Application.Dto;
	using UsingMongo.Application.Services.Mappers;
	using UsingMongo.Data.Repository.MongoDb.Repositories;

	internal sealed class CustomerService : ICustomerService
	{
		private readonly ICustomerRepository customerRepository;
		private readonly ICustomerServiceMapper customerServiceMapper;

		public CustomerService(ICustomerRepository customerRepository, ICustomerServiceMapper customerServiceMapper)
		{
			this.customerRepository = customerRepository;
			this.customerServiceMapper = customerServiceMapper;
		}

		public async Task CreateAsync(Customer customer)
		{
			var model = customerServiceMapper.MapToModel(customer);

			await customerRepository.CreateAsync(model).ConfigureAwait(false);
		}

		public Task CreateAsync(IEnumerable<Customer> customers)
		{
			throw new NotImplementedException();
		}

		public async Task<Customer> GetAsync(string id)
		{
			var model = await customerRepository.GetAsync(id).ConfigureAwait(false);

			return customerServiceMapper.MapToDto(model);
		}

		public async Task<IEnumerable<Customer>> GetAsync()
		{
			var model = await customerRepository.GetAsync().ConfigureAwait(false);

			return customerServiceMapper.MapToDto(model);
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