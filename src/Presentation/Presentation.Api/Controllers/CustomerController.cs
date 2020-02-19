namespace UsingMongo.Presentation.Api.Controllers
{
	using System.Threading.Tasks;
	using Microsoft.AspNetCore.Mvc;
	using UsingMongo.Application.Dto;
	using UsingMongo.Application.Services;

	[Route("api/[controller]")]
	[ApiController]
	public class CustomerController : ControllerBase
	{
		private readonly ICustomerService customerService;

		public CustomerController(ICustomerService customerService)
		{
			this.customerService = customerService;
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] Customer customer)
		{
			var result = await customerService.CreateAsync(customer).ConfigureAwait(false);

			return Ok(result);
		}
	}
}