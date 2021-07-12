using CrudOperations.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = CrudOperations.Model.Task;

namespace CrudOperations.Service
{
    public class TODO
    {
        private readonly IMongoCollection<Task> _TODOList;

        public TODO(IListDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _TODOList = database.GetCollection<Task>(settings.TODOListCollectionName);
        }

        public List<Task> Get() =>
            _TODOList.Find(description => true).ToList();

        public Task Get(string Work) =>
            _TODOList.Find<Task>(description => description.Work == Work).FirstOrDefault();

        public Task Create(Task description)
        {
            _TODOList.InsertOne(description);
            return description;
        }

        public void Update(string Work, Task descriptionIn) =>
            _TODOList.ReplaceOne(description => description.Work == Work, descriptionIn);

        public void Remove(Task descriptionIn) =>
            _TODOList.DeleteOne(description => description.Work == descriptionIn.Work);

        public void Remove(string Work) =>
            _TODOList.DeleteOne(description => description.Work == Work);
    }
}
