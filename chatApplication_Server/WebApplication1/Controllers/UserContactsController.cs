﻿using System;
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
        public IEnumerable<Contact> Get(string username, string filter=null)
        {
            var s = new ChatService();

            List<User> users = s.LoadContacts(username, filter);
            List<Contact> contacts = new List<Contact>();
            Contact temp = new Contact();
            int id = 0;
            foreach (User user in users)
            {
                temp.FirstName = user.FirstName;
                temp.LastName = user.LastName;
                temp.Email = user.Email;
                temp.Id = id++;
                contacts.Add(temp);
            }
            return contacts;
        }
        [HttpPost, Route("api/userContacts")]
        public void Post(AddContactToUserViewModel userContactInfo)
        {
            //Add contact to the user
            ChatService cs = new ChatService();
            string username = userContactInfo.username;
            Contact contact = userContactInfo.contact;
            cs.AddContactToUser(username, contact);
        }
    }
}
