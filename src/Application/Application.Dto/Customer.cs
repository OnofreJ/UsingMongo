namespace UsingMongo.Application.Dto
{
	/// <summary>
	/// Represents the application transfer object for Customer.
	/// </summary>
	public class Customer
	{
		/// <summary>
		/// Gets or sets the customer identifier.
		/// </summary>
		/// <value>The identifier.</value>
		public string Id { get; set; }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name { get; set; }
	}
}