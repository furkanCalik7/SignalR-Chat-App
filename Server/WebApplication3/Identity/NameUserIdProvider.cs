using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Identity {
    public class NameUserIdProvider:IUserIdProvider {
        public string GetUserId(HubConnectionContext connection) {
            Console.WriteLine("User id:" + connection.User?.Identity?.Name);
            return "123";
        }
    }
}
