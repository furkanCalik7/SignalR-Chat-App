using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Repository {
    public class ChatDatabaseSettings {
       public string MessagesCollectionName { get; set; }
       public string ConnectionString { get; set; }
       public string DatabaseName { get; set; }

    }

    public interface IChatDatabaseSettings {
        string MessagesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
