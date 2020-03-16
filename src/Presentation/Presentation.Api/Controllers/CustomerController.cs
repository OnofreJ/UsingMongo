namespace UsingMongo.Presentation.Api.Controllers
{
	using System.Collections.Generic;
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
		/// Creates the asynchronous.
		/// </summary>
		/// <param name="customer">The customer.</param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> CreateAsync([FromBody] Customer customer)
		{
			await customerService.CreateAsync(customer).ConfigureAwait(false);

			return Ok();
		}

		/// <summary>
		/// Gets the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		[HttpGet("{id}")]
		public async Task<ActionResult<Customer>> GetAsync(string id)
		{
			var result = await customerService.GetAsync(id).ConfigureAwait(false);

			return Ok(result);
		}

		/// <summary>
		/// Gets the specified identifier.
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Customer>>> GetAsync()
		{
			var result = await customerService.GetAsync().ConfigureAwait(false);

			return Ok(result);
		}

		/// <summary>
		/// Updates the asynchronous.
		/// </summary>
		/// <param name="customer">The customer.</param>
		/// <returns></returns>
		[HttpPut]
		public async Task<ActionResult<IEnumerable<Customer>>> ModifyAsync([FromBody] Customer customer)
		{
			await customerService.ModifyAsync(customer).ConfigureAwait(false);

			return Ok();
		}

		/// <summary>
		/// Removes the asynchronous.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveAsync(string id)
		{
			await customerService.RemoveAsync(id).ConfigureAwait(false);

			return Ok();
		}
	}
}