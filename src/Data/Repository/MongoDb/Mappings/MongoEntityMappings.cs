namespace UsingMongo.Data.Repository.MongoDb.Mappings
{
	using MongoDB.Bson.Serialization;
	using UsingMongo.Data.Repository.MongoDb.Model;

	public static class MongoEntityMappings
	{
		public static void Map()
		{
			BsonClassMap.RegisterClassMap<CustomerCollection>(classMapInitializer =>
			{
				classMapInitializer.AutoMap();

				//classMapInitializer.MapIdProperty(property => property.Id)
				//	.SetIdGenerator(StringObjectIdGenerator.Instance)
				//	.SetSerializer(new StringSerializer(BsonType.String));
			});
		}
	}
}