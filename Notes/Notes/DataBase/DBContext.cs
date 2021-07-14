using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Notes.Model;

namespace Notes.DataBase
{
    public class DBContext
    {
            private readonly IMongoDatabase _database = null;

        public DBContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);

        }

        public IMongoCollection<TODOList> ToDoList
        {
            get
            {
                return _database.GetCollection<TODOList>("TODOList");
            }
            set
            {
                IMongoCollection<TODOList> mongoCollection = _database.GetCollection<TODOList>("TODOList");
            }
        }
    }
}
