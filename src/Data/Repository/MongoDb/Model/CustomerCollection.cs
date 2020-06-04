using System;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace UsingMongo.Data.Repository.MongoDb.Model
{
	/// <summary>
	/// Represents the model in database for customer collection.
	/// </summary>
	public class CustomerCollection
	{
		/// <summary>
		/// Gets or sets the email.
		/// </summary>
		/// <value>The email.</value>
		public string Email { get; set; }

		/// <summary>
		/// Gets or sets the customer identifier.
		/// </summary>
		/// <value>The identifier.</value>
		[BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
		public string Id { get; set; }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the registration date.
		/// </summary>
		/// <value>The registration date.</value>
		public DateTime RegistrationDate { get; set; }
	}
}