using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MessagesCore
{
    [DataContract]
    public class User
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [StringLength(50)]
        [Index(IsUnique = true)]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }


        [DataMember]
        [StringLength(50)]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        public virtual ICollection<Message> Messages { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }


    }
}
