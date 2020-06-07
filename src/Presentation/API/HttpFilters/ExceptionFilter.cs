using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UsingMongo.Infrastructure.CrossCutting.Responses;

namespace UsingMongo.Presentation.API.HttpFilters
{
	public class ExceptionFilter : IExceptionFilter
	{
		public void OnException(ExceptionContext context)
		{
			var errorMessages = GetErrorMessages(context.Exception);
			var response = new Response<string>(null, errorMessages, null);

			context.Result = new ObjectResult(response)
			{
				StatusCode = (int)HttpStatusCode.InternalServerError
			};
			context.ExceptionHandled = true;
		}

		private IEnumerable<string> GetErrorMessages(Exception exception)
		{
			if (exception != null)
			{
				if (exception.InnerException != null)
				{
					GetErrorMessages(exception.InnerException);
				}
				else
				{
					yield return exception.Message;
				}
			}
		}
	}
}