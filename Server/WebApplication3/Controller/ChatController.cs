using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.JwtTokenAuthentication;
using WebApplication3.Utils;

namespace WebApplication3.Controller {
    
    [Authorize]
    [Route("dot")]
    [ApiController]
    public class ChatController : ControllerBase {


        public readonly IJwtTokenAuthenticationManager jwtTokenAuthenticationManager;

        public ChatController(IJwtTokenAuthenticationManager jwtTokenAuthenticationManager) {
            this.jwtTokenAuthenticationManager = jwtTokenAuthenticationManager;
        }

        [HttpGet("GetData")]
        public IEnumerable<string> GetData() {
            return new string[]{ "Your achieved", "Congratulations"};
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult authenticate([FromBody] UserInfo userInfo) {
            string token = this.jwtTokenAuthenticationManager.Authenticate(userInfo.username, userInfo.password);
            if(token == null) {
                return Unauthorized();
            }
            Console.WriteLine("Username: " + userInfo.username + " - password: " + userInfo.password);
            Console.WriteLine("Token:" + token);
            return Ok(token);
        }
    }
}
