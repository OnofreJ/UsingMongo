namespace UsingMongo.Application.Dto
{
	using System;
	using System.ComponentModel.DataAnnotations;

	/// <summary>
	/// Represents the application transfer object for Customer.
	/// </summary>
	public class Customer
	{
		/// <summary>
		/// Gets or sets the email.
		/// </summary>
		/// <value>The email.</value>
		[Required]
		[EmailAddress]
		[StringLength(50)]
		public string Email { get; set; }

		/// <summary>
		/// Gets or sets the customer identifier.
		/// </summary>
		/// <value>The identifier.</value>
		public string Id { get; set; }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		[Required]
		[StringLength(100)]
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the registration date.
		/// </summary>
		/// <value>The registration date.</value>
		[Required]
		public DateTime RegistrationDate { get; set; }
	}
}