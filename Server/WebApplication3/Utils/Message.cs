using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApplication3.Utils {
    public class Message { 
        [BsonId]
        public ObjectId id { get; set; }

        [BsonElement("Username")]
        public string user { get; set; } 

        [BsonElement("Text")]
        public string text { get; set; }

        [BsonElement("Date")]
        public string date { get; set; }

        [BsonElement("Room")]
        public string room { get; set; }

        public Message(string user, string room, string text) {
            this.user = user;
            this.text = text;
            this.room = room;
            this.date = DateTimeOffset.Now.LocalDateTime.ToString();
        }
    }

}
