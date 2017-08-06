using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesCore
{
    public class ChatService
    {

        public bool CheckIfValidLogin(string Username, string Password)
        {
            using (var db = new ChatAppContext())
            {
                if (db.Users.Any(c => c.Username == Username && c.Password == Password))
                {
                    return true;
                }
                return false;
            }


        }


        public void RegisterUser(User user)
        {
            using (var db = new ChatAppContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }
    }
}
