﻿namespace UsingMongo.Data.Repository.MongoDb.Repositories
{
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using Data.Repository.MongoDb.Model;
	using MongoDB.Driver;
	using UsingMongo.Data.Repository.MongoDb.Client;

	/// <summary>
	/// </summary>
	/// <seealso cref="MongoRepositoryBase{Customer}"/>
	/// <seealso cref="ICustomerRepository"/>
	internal sealed class CustomerRepository : MongoRepositoryBase<Customer>, ICustomerRepository
	{
		private const string CollectionName = "CustomerCollection";

		public CustomerRepository(IMongoDatabaseClient mongoClient) : base(mongoClient, CollectionName)
		{
		}

		public async Task<Customer> CreateAsync(Customer customer)
		{
			var result = await InsertAsync(customer);

			return result;
		}

		public Task<IEnumerable<Customer>> CreateAsync(IEnumerable<Customer> customers)
		{
			throw new System.NotImplementedException();
		}

		public Task<Customer> GetAsync(string id)
		{
			throw new System.NotImplementedException();
		}

		Task<IEnumerable<Customer>> ICustomerRepository.GetAsync()
		{
			throw new System.NotImplementedException();
		}

		public Task RemoveAllAsync()
		{
			throw new System.NotImplementedException();
		}

		public Task RemoveAsync(string id)
		{
			throw new System.NotImplementedException();
		}

		public Task UpdateAsync(Customer customer)
		{
			throw new System.NotImplementedException();
		}

		//public async Task DeleteAllCustomers()
		//{
		//	var filter = CreateEmptyFilter<Customer>();

		//	await DeleteAsync(filter);
		//}

		//public async Task<Customer> GetCustomerAsync(string id)
		//{
		//	var filter = Builders<Customer>.Filter.Eq(x => x.Id, id);

		// var result = await FindAsync(filter);

		//	return result;
		//}

		//public async Task<IEnumerable<Customer>> GetCustomersAsync(int tenantId)
		//{
		//	var filter = GetFilterByTenantId(tenantId);

		// var result = await GetAsync(filter);

		//	return result;
		//}

		//public async Task<Customer> InsertCustomersAsync(Customer customer)
		//{
		//	var result = await InsertAsync(customer);

		//	return result;
		//}

		//public async Task<IEnumerable<Customer>> InsertCustomersAsync(IEnumerable<Customer> customers)
		//{
		//	var result = await InsertAsync(customers);

		//	return result;
		//}

		//public async Task UpdateDescriptionAsync(Customer customer)
		//{
		//	var filter = Builders<Customer>.Filter.Eq(x => x.Id, customer.Id);
		//	//var update = Builders<Customer>.Update.Push("Description", customer.Description);

		//	await UpdatePropertyAsync(filter, update);
		//}

		private FilterDefinition<T> CreateEmptyFilter<T>()
		{
			return Builders<T>.Filter.Empty;
		}

		private FilterDefinition<Customer> GetFilterById(string id)
		{
			var filter = Builders<Customer>.Filter.Eq(x => x.Id, id);

			return filter;
		}
	}
}