using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesCore
{
    public class Message
    {
        //only shows the message that the user sent
        public int Id { get; set; }
        public DateTimeOffset Date { get; set; }
      //  [ForeignKey("User")]
        public int fromUserId { get; set; }

       // [ForeignKey("User")]
        public int toUserId { get; set; }

        public string message { get; set; }
        public virtual User user { get; set; }
    }
}
