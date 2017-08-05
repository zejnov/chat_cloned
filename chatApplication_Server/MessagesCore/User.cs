using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;


namespace MessagesCore
{
    public class User
    {
        public int Id { get; set; }

        [Index(IsUnique = true)]
        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }



        [StringLength(50)]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        public virtual ICollection<Message> Messages { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }


    }
}
