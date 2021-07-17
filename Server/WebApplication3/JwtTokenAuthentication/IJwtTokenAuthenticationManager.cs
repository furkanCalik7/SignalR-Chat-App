using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.JwtTokenAuthentication {
    public interface IJwtTokenAuthenticationManager {
        string Authenticate(string username, string password);
    }
}
