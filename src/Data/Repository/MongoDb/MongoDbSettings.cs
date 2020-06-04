namespace UsingMongo.Data.Repository.MongoDb
{
	using System.Diagnostics.CodeAnalysis;

	/// <summary>
	/// Represents the settings to configure MongoDB.
	/// </summary>
	[ExcludeFromCodeCoverage]
	public class MongoDbSettings
	{
		/// <summary>
		/// Gets or sets the connection string.
		/// </summary>
		/// <value>The connection string.</value>
		public string ConnectionString { get; set; }

		/// <summary>
		/// Gets or sets the name of the database.
		/// </summary>
		/// <value>The name of the database.</value>
		public string DatabaseName { get; set; }
	}
}