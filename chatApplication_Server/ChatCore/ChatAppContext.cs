using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesCore
{
    class ChatAppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Message> Messages { get; set; }
    //    public DbSet<UserMessage> UserMessages { get; set; }

        public ChatAppContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ChatAppContext>());

        }

    }
}
