using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UsingMongo.Infrastructure.CrossCutting.Responses;

namespace UsingMongo.Presentation.API.HttpFilters
{
	/// <summary>
	/// Represents the application filter class that surrounds execution of the action.
	/// </summary>
	/// <seealso cref="IActionFilter"/>
	[ExcludeFromCodeCoverage]
	internal sealed class ModelStateActionFilter : IActionFilter
	{
		/// <summary>
		/// Called after the action executes, before the action result.
		/// </summary>
		/// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext"/>.</param>
		public void OnActionExecuted(ActionExecutedContext context) { }

		/// <summary>
		/// Called before the action executes, after model binding is complete.
		/// </summary>
		/// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext"/>.</param>
		public void OnActionExecuting(ActionExecutingContext context)
		{
			if (!context.ModelState.IsValid)
			{
				var modelMessages = context.ModelState.Values.SelectMany(selector => selector.Errors)
					.Select(selector => string.IsNullOrWhiteSpace(selector.ErrorMessage) ? selector.Exception.Message : selector.ErrorMessage);

				var errorResponse = new Response<string>(null, null, modelMessages);

				context.Result = new ObjectResult(errorResponse)
				{
					StatusCode = (int)HttpStatusCode.BadRequest
				};
			}
		}
	}
}