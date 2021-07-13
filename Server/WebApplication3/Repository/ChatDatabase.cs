using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Utils;

namespace WebApplication3.Repository {
    public class ChatDatabase {
        private readonly IMongoCollection<Message> _messages;
        private readonly IMongoCollection<ChatUser> _users;

        //public ChatDatabase(IChatDatabaseSettings settings) {
        //    var client = new MongoClient(settings.ConnectionString);
        //    var database = client.GetDatabase(settings.DatabaseName);
        //    _messages = database.GetCollection<Message>(settings.MessagesCollectionName);
        //}

        public ChatDatabase() {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("ChatApp");
            _messages = database.GetCollection<Message>("Messages");
            _users = database.GetCollection<ChatUser>("Users");
        }

        public List<Message> GetMessages() {
            return _messages.Find(message => true).ToList();
        }

        public Message CreateNewMessage(Message message) {
            _messages.InsertOne(message);
            return message;
        }
        
        public bool ChechUsernameIsAvailable(string username, string room) {
            List<ChatUser> list = _users.Find(user => user.username == username && user.room == room).ToList();
            return list.Count == 0;
        }

        public List<ChatUser> GetUsers(string room) {
            return _users.Find(user => user.room == room).ToList();
        }

        public ChatUser CreateUser(ChatUser user) {
            _users.InsertOne(user);
            return user;
        }

        public void RemoveUser(string username, string room) {
            Console.WriteLine(username + " " + room);
            Console.WriteLine(_users.DeleteOne(user => user.username == username && user.room == room));
          //  Console.WriteLine(_users.DeleteMany(user => true));
        }
    }
}
