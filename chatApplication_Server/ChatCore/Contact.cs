using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace MessagesCore
{
    [DataContract]
    public class Contact
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string LastMessageText { get; set; } //specifies last message text happend between this
                                                    // contact and the user that have this contact

        [StringLength(50)]
        [Index(IsUnique = true)]
        [DataMember]
        public string Email { get; set; }

        public virtual User User { get; set; }
    }
}
