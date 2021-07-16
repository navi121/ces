using FileHand.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FileHand.DataBase
{
    public class DBContext
    {
        public readonly IMongoDatabase _database = null;

        public DBContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
                _database = client.GetDatabase(settings.Value.Database);

        }
        public IMongoCollection<FileEntity> fileUpload
        {
            get
            {
                return _database.GetCollection<FileEntity>("Upload");
            }
            set
            {
                IMongoCollection<FileEntity> mongoCollection = _database.GetCollection<FileEntity>("Upload");
            }
        }
    }
}
