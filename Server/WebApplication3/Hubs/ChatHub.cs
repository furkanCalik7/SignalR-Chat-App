using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Repository;
using WebApplication3.Utils;

namespace WebApplication3.Hubs {
    [Authorize]
    public class ChatHub: Hub<IChatClient> {

        public readonly ChatDatabase chatDB;

        public ChatHub(ChatDatabase chatDB) {
            this.chatDB = chatDB;
        }

        public async Task SendMessage(string user, string message, string room) {
            Message messageJson = new Message(user, room, message);
            messageJson = chatDB.CreateNewMessage(messageJson);
            await Clients.Group(room).receiveMessage(messageJson);
        }

        public override async Task OnConnectedAsync() {
            Console.WriteLine("New client is connected");
            Console.WriteLine(Context.User.Identity.IsAuthenticated);
            await base.OnConnectedAsync();
        }

        public async Task ManifestNewUser(string username, string room) {
            Console.WriteLine("ManifestNewUser() called");
            string message = username + " jumped to the chat.";
            Message messageJson = chatDB.CreateNewMessage(new Message("Chat Bot", room, message));
            await Clients.Group(room).receiveMessage(messageJson);
        }

        public override Task OnDisconnectedAsync(Exception exception) {
            Console.WriteLine("A client disconnected");
            return base.OnDisconnectedAsync(exception);
        }

        public async Task GetUsers(string room) {
        
            await Clients.Group(room).updateUsers(chatDB.GetUsers(room));
        }
        public async Task CreateUser(string username, string room) {
            ChatUser user = new ChatUser(username,room);
            chatDB.CreateUser(user);
            await Groups.AddToGroupAsync(Context.ConnectionId, room);
            await Clients.Group(room).updateUsers(chatDB.GetUsers(room));
        }

        public async Task RemoveUser(string username, string room) {
            chatDB.RemoveUser(username, room);
            Message messageJson = chatDB.CreateNewMessage(new Message("Chat Bot", room, username + " left the chat."));
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, room);
            await Clients.Group(room).updateUsers(chatDB.GetUsers(room));
            await Clients.Group(room).receiveMessage(messageJson);
        }
    }
}
