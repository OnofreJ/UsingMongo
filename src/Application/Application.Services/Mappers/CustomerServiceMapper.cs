namespace UsingMongo.Application.Services.Mappers
{
	using UsingMongo.Data.Repository.MongoDb.Model;

	internal sealed class CustomerServiceMapper : ICustomerServiceMapper
	{
		public Dto.Customer MapToDto(Customer customer)
		{
			return new Dto.Customer { Id = customer.Id, Name = customer.Name };
		}

		public Customer MapToModel(Dto.Customer customer)
		{
			return new Customer { Id = customer.Id, Name = customer.Name };
		}
	}
}