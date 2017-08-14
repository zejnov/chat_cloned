using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MessagesCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UserController : ApiController
    {


        [HttpPost, Route("api/user")]
        public IHttpActionResult Post(UserContactViewModel userContact)
        {
            var s = new ChatService();
            if(s.SendMessage(userContact.Username,userContact.OtherUsernameEmail,userContact.Message))
            {
                return Ok();
            }
            return NotFound();
        }


        [HttpGet, Route("api/user")]
        public IEnumerable<string> Get(UserContactViewModel userContact)
        {
            var s = new ChatService();
            return s.LoadMessages(userContact.Username, userContact.OtherUsernameEmail);
        }
    }
}
