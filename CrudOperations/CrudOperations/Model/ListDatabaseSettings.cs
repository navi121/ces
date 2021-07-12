using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperations.Model
{
    public class ListDatabaseSettings : IListDatabaseSettings
    {
        public string TODOListCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface IListDatabaseSettings
    {
        public string TODOListCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
