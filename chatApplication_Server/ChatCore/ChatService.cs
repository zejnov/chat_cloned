using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesCore
{
    public class ChatService
    {

        public bool CheckIfValidLogin(string username, string password)
        {
            using (var db = new ChatAppContext())
            {
                if (db.Users.Any(c => c.Username == username && c.Password == password))
                {
                    return true;
                }
                return false;
            }


        }

        //TODO: check if username or email already exsits
        //if yes then return relative status code
        public void RegisterUser(User user)
        {
            using (var db = new ChatAppContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }
        public List<User> LoadContacts(string username, string filter = "")
        {
            using (var db = new ChatAppContext())
            {
            //    User userInDB = db.Users.Find(username);
                IQueryable<User> contacts;
                if (!string.IsNullOrEmpty(filter))
                {
                    contacts = from e in db.Users
                               where (e.Username != username) && (e.FirstName.Contains(filter))
                               select e;

                    return contacts.ToList();
                }
                contacts = from e in db.Users
                           where e.Username != username
                           select e;

                return contacts.ToList();
            }
        }

        public void AddContactToUser(string username, Contact contact)
        {
            using (var db = new ChatAppContext())
            {
                User myUser = db.Users.SingleOrDefault(user => user.Username == username);
                if (myUser != null)
                {
                    User userInDB = db.Users.Find(myUser.Id);
                    contact.User = userInDB;
                    db.Contacts.Add(contact);
                    userInDB.Contacts.Add(contact);
                    db.Entry(userInDB).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }
        public List<string> LoadMessages(string username, string otherUserEmail)
        {
            using (var db = new ChatAppContext())
            {
                User myUser = db.Users.SingleOrDefault(user => user.Username == username);
                User otherUser = db.Users.SingleOrDefault(user => user.Email == otherUserEmail);

                List<string> MessagesBetweenTwoUsers = new List<string>();

                if (myUser != null && otherUser != null)
                {


                    //User userInDB = db.Users.Find(myUser);
                    List<Message> MessagesInDB = myUser.Messages.ToList();
                    foreach (Message msg in MessagesInDB)
                    {
                        if ((msg.fromUserId == myUser.Id && msg.toUserId == otherUser.Id) ||
                            (msg.fromUserId == otherUser.Id && msg.toUserId == myUser.Id))
                        {
                            MessagesBetweenTwoUsers.Add(msg.message);
                        }
                        //need to update message status to Read
                    }

                }
                return MessagesBetweenTwoUsers;

            }
        }

        public void SendMessage(string usernameFrom, string userToEmail, string messageText)
        {
            using (var db = new ChatAppContext())
            {
                User userFrom = db.Users.SingleOrDefault(user => user.Username == usernameFrom);
                User userTo = db.Users.SingleOrDefault(user => user.Email == userToEmail);

                if(userFrom != null && userTo != null && !String.IsNullOrEmpty(messageText))
                {
                    Message messageFrom = new Message();
                    messageFrom.fromUserId = userFrom.Id;
                    messageFrom.toUserId = userTo.Id;
                    messageFrom.message = messageText;
                    messageFrom.user = userFrom;
                    userFrom.Messages.Add(messageFrom);
                    Message messageTo = new Message();
                    messageTo.fromUserId = userFrom.Id;
                    messageTo.toUserId = userTo.Id;
                    messageTo.message = messageText;
                    messageTo.user = userTo;
                    userTo.Messages.Add(messageTo);
                    //Message must be set as new here

                    Contact contactTo = userFrom.Contacts.SingleOrDefault(contact => contact.Email == userTo.Email);
                    contactTo.LastMessageText = messageText;
              //      db.Entry(userFrom).State = System.Data.Entity.EntityState.Modified;
              //      db.Entry(userTo).State = System.Data.Entity.EntityState.Modified;
              //      db.Entry(contactTo).State = System.Data.Entity.EntityState.Modified;

                    db.SaveChanges();

                }
            }
        }
    }
}
