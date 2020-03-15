namespace UsingMongo.Application.Services.Mappers
{
	using UsingMongo.Data.Repository.MongoDb.Model;

	/// <summary>
	/// </summary>
	public interface ICustomerServiceMapper
	{
		Dto.Customer MapToDto(Customer customer);

		Customer MapToModel(Dto.Customer customer);
	}
}