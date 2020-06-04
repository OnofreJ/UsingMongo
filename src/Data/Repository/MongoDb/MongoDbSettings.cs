namespace UsingMongo.Data.Repository.MongoDb
{
	using System.Diagnostics.CodeAnalysis;

	[ExcludeFromCodeCoverage]
	public class MongoDbSettings
	{
		public string ConnectionString { get; set; }
		public string DatabaseName { get; set; }
	}
}