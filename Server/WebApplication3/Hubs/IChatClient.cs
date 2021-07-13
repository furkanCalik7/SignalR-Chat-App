using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Utils;

namespace WebApplication3.Hubs {
    public interface IChatClient {

        Task receiveMessage(Message message);
        Task updateUsers(List<ChatUser> users);

    }
}
