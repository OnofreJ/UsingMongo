using System.Collections.Generic;
using System.Linq;

namespace UsingMongo.Infrastructure.CrossCutting.Responses
{
	/// <summary>
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Response<T>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Response{T}"/> class.
		/// </summary>
		/// <param name="result">The result.</param>
		/// <param name="errorMessages">The error messages.</param>
		/// <param name="messages">The messages.</param>
		public Response(T result, IEnumerable<string> errorMessages, IEnumerable<string> messages)
		{
			Result = result;
			ErrorMessages = errorMessages ?? Enumerable.Empty<string>();
			Messages = messages ?? Enumerable.Empty<string>();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Response{T}"/> class.
		/// </summary>
		/// <param name="result">The result.</param>
		public Response(T result)
		{
			Result = result;
			ErrorMessages = Enumerable.Empty<string>();
			Messages = Enumerable.Empty<string>();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Response{T}"/> class.
		/// </summary>
		public Response() { }

		/// <summary>
		/// Gets or sets the error messages.
		/// </summary>
		/// <value>The error messages.</value>
		public IEnumerable<string> ErrorMessages { get; }

		/// <summary>
		/// Returns true if the response is valid.
		/// </summary>
		/// <value><c>true</c> if the response is valid; otherwise, <c>false</c>.</value>
		public bool IsValid => !Messages.Any() && !ErrorMessages.Any();

		/// <summary>
		/// Gets or sets the messages.
		/// </summary>
		/// <value>The messages.</value>
		public IEnumerable<string> Messages { get; }

		/// <summary>
		/// Gets the result.
		/// </summary>
		/// <value>The result.</value>
		public T Result { get; }
	}
}