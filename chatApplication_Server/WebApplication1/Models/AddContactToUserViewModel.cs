using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MessagesCore;
namespace WebApplication1.Models
{
    public class AddContactToUserViewModel
    {
        public string username { get; set;}
        public Contact contact { get; set; }
    }
}