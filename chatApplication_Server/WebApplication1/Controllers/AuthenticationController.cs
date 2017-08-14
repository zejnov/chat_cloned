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

        //http://localhost:64014a/pi/authentication
        [HttpPost, Route("api/authentication")]
        public IHttpActionResult Post([FromBody]User user)
        {
            var s = new ChatService();
            try
            {
                s.RegisterUser(user);
            }
            catch(Exception e)
            {
                return Ok("Already exsists");
            }
            
            return Ok();
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
