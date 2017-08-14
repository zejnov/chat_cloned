using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MessagesCore;
namespace WebApplication1.Models
{
    public class AddContactToUserViewModel
    {
        public string Username { get; set;}
        public Contact Contact { get; set; }
    }
}