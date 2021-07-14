using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Notes.Model
{
    public class TODOList
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId InternalId { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string work { get; set; }
    }
}
