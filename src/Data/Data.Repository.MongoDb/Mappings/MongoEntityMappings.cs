namespace UsingMongo.Data.Repository.MongoDb.Mappings
{
	using MongoDB.Bson;
	using MongoDB.Bson.Serialization;
	using MongoDB.Bson.Serialization.IdGenerators;
	using MongoDB.Bson.Serialization.Serializers;
	using UsingMongo.Data.Repository.MongoDb.Model;

	/// <summary>
	/// Represents the class with the mapper implementation.
	/// </summary>
	public static class MongoEntityMappings
	{
		/// <summary>
		/// This method performs the mapping of the model in MongoDB.
		/// </summary>
		public static void Map()
		{
			BsonClassMap.RegisterClassMap<Customer>(classMapInitializer =>
			{
				classMapInitializer.AutoMap();
				classMapInitializer.MapIdProperty(property => property.Id)
					.SetIdGenerator(StringObjectIdGenerator.Instance)
					.SetSerializer(new StringSerializer(BsonType.ObjectId));
			});
		}
	}
}