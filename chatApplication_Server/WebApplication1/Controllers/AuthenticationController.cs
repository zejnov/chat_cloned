using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MessagesCore;
namespace WebApplication1.Controllers
{
    public class AuthenticationController : ApiController
    {
        //Register
        // POST api/values

        //http://localhost:64014/api/authentication
        [HttpPost, Route("api/authentication")]
        public string Post([FromBody]User user)
        {
            var s = new ChatService();
            s.RegisterUser(user);
            return "success";
        }


        //http://localhost:64014/api/authentication?Username=Mia&Password=dsad
        [HttpGet, Route("api/authentication")]
        public bool Get(string username, string password)
        {
            var s = new ChatService();

            return s.CheckIfValidLogin(username, password);
        }
    }
}
