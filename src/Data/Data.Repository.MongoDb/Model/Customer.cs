namespace UsingMongo.Data.Repository.MongoDb.Model
{
	/// <summary>
	/// Represents the model in database for Customer.
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