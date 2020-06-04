namespace UsingMongo.Application.Services.Mappers
{
	using System.Collections.Generic;
	using System.Linq;
	using UsingMongo.Application.Dto;
	using UsingMongo.Data.Repository.MongoDb.Model;

	internal sealed class CustomerServiceMapper : ICustomerServiceMapper
	{
		public Customer MapToDto(CustomerCollection customer)
		{
			return new Customer
			{
				Email = customer.Email,
				RegistrationDate = customer.RegistrationDate,
				Id = customer.Id,
				Name = customer.Name
			};
		}

		public IEnumerable<Customer> MapToDto(IEnumerable<CustomerCollection> collection)
		{
			var customers = collection ?? Enumerable.Empty<CustomerCollection>();

			foreach (var customer in customers)
			{
				yield return MapToDto(customer);
			}
		}

		public IEnumerable<CustomerCollection> MapToModel(IEnumerable<Customer> collection)
		{
			var customers = collection ?? Enumerable.Empty<Customer>();

			foreach (var customer in customers)
			{
				yield return MapToModel(customer);
			}
		}

		public CustomerCollection MapToModel(Customer customer)
		{
			return new CustomerCollection
			{
				Email = customer.Email,
				RegistrationDate = customer.RegistrationDate,
				Id = customer.Id,
				Name = customer.Name
			};
		}
	}
}