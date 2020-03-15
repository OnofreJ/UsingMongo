namespace UsingMongo.Application.Services.Mappers
{
	using System.Collections.Generic;
	using UsingMongo.Data.Repository.MongoDb.Model;

	internal sealed class CustomerServiceMapper : ICustomerServiceMapper
	{
		public Dto.Customer MapToDto(Customer customer)
		{
			return new Dto.Customer { Id = customer.Id, Name = customer.Name };
		}

		public IEnumerable<Dto.Customer> MapToDto(IEnumerable<Customer> customers)
		{
			foreach (var customer in customers)
			{
				yield return MapToDto(customer);
			}
		}

		public IEnumerable<Customer> MapToModel(IEnumerable<Dto.Customer> customers)
		{
			foreach (var customer in customers)
			{
				yield return MapToModel(customer);
			}
		}

		public Customer MapToModel(Dto.Customer customer)
		{
			return new Customer { Id = customer.Id, Name = customer.Name };
		}
	}
}