namespace UsingMongo.Application.Services.Mappers
{
	using System.Collections.Generic;
	using System.Linq;
	using UsingMongo.Data.Repository.MongoDb.Model;

	internal sealed class CustomerServiceMapper : ICustomerServiceMapper
	{
		public Dto.Customer MapToDto(Customer customer)
		{
			if (customer == null)
			{
				return default;
			}

			return new Dto.Customer { Id = customer.Id, Name = customer.Name };
		}

		public IEnumerable<Dto.Customer> MapToDto(IEnumerable<Customer> customers)
		{
			customers = customers ?? Enumerable.Empty<Customer>();

			foreach (var customer in customers)
			{
				yield return MapToDto(customer);
			}
		}

		public IEnumerable<Customer> MapToModel(IEnumerable<Dto.Customer> customers)
		{
			customers = customers ?? Enumerable.Empty<Dto.Customer>();

			foreach (var customer in customers)
			{
				yield return MapToModel(customer);
			}
		}

		public Customer MapToModel(Dto.Customer customer)
		{
			if (customer == null)
			{
				return default;
			}

			return new Customer { Id = customer.Id, Name = customer.Name };
		}
	}
}