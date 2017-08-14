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
    public class UserContactsController : ApiController
    {
        //http://localhost:64014/api/userContacts?UserId=2
        [HttpGet, Route("api/userContacts")]
        public IEnumerable<User> Get(string username, string filter=null)
        {
            var s = new ChatService();

            List<User> users = s.LoadContacts(username, filter);
            return users;
        }
        [HttpPost, Route("api/userContacts")]
        public IHttpActionResult Post(AddContactToUserViewModel userContactInfo)
        {
            //Add contact to the user
            ChatService cs = new ChatService();
            string username = userContactInfo.username;
            Contact contact = userContactInfo.contact;
            if (cs.AddContactToUser(username, contact))
                return Ok();

            return NotFound();
        }
    }
}
