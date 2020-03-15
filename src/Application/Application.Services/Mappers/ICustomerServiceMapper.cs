namespace UsingMongo.Application.Services.Mappers
{
	using System.Collections.Generic;
	using UsingMongo.Data.Repository.MongoDb.Model;

	/// <summary>
	/// </summary>
	public interface ICustomerServiceMapper
	{
		Dto.Customer MapToDto(Customer customer);

		IEnumerable<Dto.Customer> MapToDto(IEnumerable<Customer> customers);

		Customer MapToModel(Dto.Customer customer);

		IEnumerable<Customer> MapToModel(IEnumerable<Dto.Customer> customers);
	}
}