namespace UsingMongo.Presentation.API.Controllers
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.Linq;
	using System.Threading.Tasks;
	using Microsoft.AspNetCore.Http;
	using Microsoft.AspNetCore.Mvc;
	using UsingMongo.Application.Dto;
	using UsingMongo.Application.Services;
	using UsingMongo.Infrastructure.CrossCutting.Responses;

	[Route("api/[controller]")]
	[ApiController]
	public class CustomersController : ControllerBase
	{
		private readonly ICustomerService _customerService;

		/// <summary>
		/// Initializes a new instance of the <see cref="CustomerController"/> class.
		/// </summary>
		/// <param name="_customerService">The customer service.</param>
		public CustomersController(ICustomerService customerService)
		{
			_customerService = customerService;
		}

		[HttpPost]
		[ProducesResponseType(typeof(Customer), StatusCodes.Status201Created)]
		[ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
		[ProducesResponseType(typeof(Response<string>), StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> CreateAsync([FromBody] Customer customer)
		{
			var customerId = await _customerService.CreateAsync(customer).ConfigureAwait(false);

			return CreatedAtRoute("GetAsync", new { id = customerId }, customer);
		}

		[HttpGet("{id}")]
		[ProducesResponseType(typeof(Response<Customer>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(Response<string>), StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(typeof(Response<string>), StatusCodes.Status404NotFound)]
		public async Task<ActionResult<Customer>> GetAsync([Required] string id)
		{
			var customer = await _customerService.GetAsync(id).ConfigureAwait(false);

			if (customer == null)
			{
				return NotFound(new Response<string>());
			}

			return Ok(new Response<Customer>(customer));
		}

		[HttpGet]
		[ProducesResponseType(typeof(Response<IEnumerable<Customer>>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(Response<string>), StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(typeof(Response<string>), StatusCodes.Status404NotFound)]
		public async Task<ActionResult<IEnumerable<Customer>>> GetAsync()
		{
			var customers = await _customerService.GetAsync().ConfigureAwait(false);

			if (customers == null && customers.Any())
			{
				return NotFound(new Response<string>());
			}

			return Ok(new Response<IEnumerable<Customer>>(customers));
		}

		[HttpPut]
		[ProducesResponseType(typeof(Customer), StatusCodes.Status201Created)]
		[ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
		[ProducesResponseType(typeof(Response<string>), StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult> ModifyAsync([FromBody] Customer customer)
		{
			await _customerService.ModifyAsync(customer).ConfigureAwait(false);

			return CreatedAtRoute("GetAsync", new { id = customer.Id }, customer);
		}

		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(Response<string>), StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> RemoveAsync([Required] string id)
		{
			await _customerService.RemoveAsync(id).ConfigureAwait(false);

			return Ok();
		}
	}
}