using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Utils {
    public class ChatUser {
        
        [BsonId]
        public ObjectId id { get; set; }
        
        [BsonElement("Username")]
        public string username { get; set; }

        [BsonElement("Room")]
        public string room { get; set; }

        public ChatUser(string username, string room) {
            this.username = username;
            this.room = room;
        }
    }
}
