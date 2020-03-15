namespace UsingMongo.Presentation.Api.Controllers
{
	using System.Threading.Tasks;
	using Microsoft.AspNetCore.Mvc;
	using UsingMongo.Application.Dto;
	using UsingMongo.Application.Services;

	/// <summary>
	/// </summary>
	/// <seealso cref="ControllerBase"/>
	[Route("api/customer")]
	[ApiController]
	public class CustomerController : ControllerBase
	{
		private readonly ICustomerService customerService;

		/// <summary>
		/// Initializes a new instance of the <see cref="CustomerController"/> class.
		/// </summary>
		/// <param name="customerService">The customer service.</param>
		public CustomerController(ICustomerService customerService)
		{
			this.customerService = customerService;
		}

		/// <summary>
		/// Gets the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		[HttpGet]
		public async Task<IActionResult> Get([FromQuery] string id)
		{
			var result = await customerService.GetAsync(id).ConfigureAwait(false);

			return Ok(result);
		}

		/// <summary>
		/// Posts the specified customer.
		/// </summary>
		/// <param name="customer">The customer.</param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] Customer customer)
		{
			await customerService.CreateAsync(customer).ConfigureAwait(false);

			return Ok();
		}
	}
}