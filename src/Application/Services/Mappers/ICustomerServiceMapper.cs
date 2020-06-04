using System.Collections.Generic;
using UsingMongo.Application.Dto;
using UsingMongo.Data.Repository.MongoDb.Model;

namespace UsingMongo.Application.Services.Mappers
{
	public interface ICustomerServiceMapper
	{
		Customer MapToDto(CustomerCollection customer);

		IEnumerable<Customer> MapToDto(IEnumerable<CustomerCollection> customers);

		CustomerCollection MapToModel(Customer customer);

		IEnumerable<CustomerCollection> MapToModel(IEnumerable<Customer> customers);
	}
}