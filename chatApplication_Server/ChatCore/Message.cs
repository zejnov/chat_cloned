using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MessagesCore
{
    [DataContract]
    public class Message
    {
        //only shows the message that the user sent
        [DataMember]
        public int Id { get; set; }
        public DateTimeOffset Date { get; set; }
        [DataMember]
        public int FromUserId { get; set; }

        [DataMember]
        public int ToUserId { get; set; }
        [DataMember]
        public string MessageText { get; set; }

        [DataMember]
        public bool IsNew { get; set; }

        public virtual User User { get; set; }
    }
}
