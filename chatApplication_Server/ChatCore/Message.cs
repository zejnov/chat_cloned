using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesCore
{
    public class Message
    {
        public int Id { get; set; }
        public DateTimeOffset Date { get; set; }
        public virtual User user { get; set; }
    }
}
