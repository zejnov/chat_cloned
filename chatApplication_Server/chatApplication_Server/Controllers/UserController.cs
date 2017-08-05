using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ChatCore

namespace chatApplication_Server.Controllers
{
    public class UserController : ApiController
    {

        // POST api/values
        public IHttpActionResult Post(string username, string password)
        {
            var s = new ChatService();
            s.SaveMessage(message);
            return message;
        }
    }
}
