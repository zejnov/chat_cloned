﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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
                if(db.Users.Any(u => u.Username == user.Username || u.Email == user.Email))
                {
                    throw new UserNameOrEmailAlreadyExistsException();
                }
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

        public Boolean AddContactToUser(string username, Contact contact)
        {
            using (var db = new ChatAppContext())
            {
                User myUser = db.Users.SingleOrDefault(user => user.Username == username);
                //check if contact exists
                User contactAsUser = db.Users.SingleOrDefault(user => user.Email == contact.Email); 
                if (myUser == null || contactAsUser == null)
                {
                    return false;
                }
                contact.User = myUser;
                db.Contacts.Add(contact);
                myUser.Contacts.Add(contact);
                db.SaveChanges();
                return true;

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
                    List<Message> MessagesInDB = myUser.Messages.ToList();
                    foreach (Message msg in MessagesInDB)
                    {
                        if ((msg.FromUserId == myUser.Id && msg.ToUserId == otherUser.Id) ||
                            (msg.FromUserId == otherUser.Id && msg.ToUserId == myUser.Id))
                        {
                            if(msg.IsNew) {
                                MessagesBetweenTwoUsers.Add(msg.MessageText);
                                msg.IsNew = false;
                            }
                        }
                        //need to update message status to Read
                    }

                }
                return MessagesBetweenTwoUsers;

            }
        }

        public Boolean SendMessage(string usernameFrom, string userToEmail, string messageText)
        {
            using (var db = new ChatAppContext())
            {
                User userFrom = db.Users.SingleOrDefault(user => user.Username == usernameFrom);
                User userTo = db.Users.SingleOrDefault(user => user.Email == userToEmail);

                if (userFrom == null || userTo == null)
                {
                    return false;
                }
                Message messageFrom = new Message();
                messageFrom.FromUserId = userFrom.Id;
                messageFrom.ToUserId = userTo.Id;
                messageFrom.MessageText = messageText;
                messageFrom.User = userFrom;
                messageFrom.Date = DateTimeOffset.UtcNow;
                messageFrom.IsNew = true;
                userFrom.Messages.Add(messageFrom);
                Message messageTo = new Message();
                messageTo.FromUserId = userFrom.Id;
                messageTo.ToUserId = userTo.Id;
                messageTo.MessageText = messageText;
                messageTo.User = userTo;
                messageTo.Date = DateTimeOffset.UtcNow;
                messageTo.IsNew = true;
                userTo.Messages.Add(messageTo);
                Contact contactTo = userFrom.Contacts.SingleOrDefault(contact => contact.Email == userTo.Email);
                contactTo.LastMessageText = messageText;

                db.SaveChanges();
                return true;

            }
        }

        [Serializable]
        public class UserNameOrEmailAlreadyExistsException : Exception
        {
            public UserNameOrEmailAlreadyExistsException()
            {
            }

            public UserNameOrEmailAlreadyExistsException(string message) : base(message)
            {
            }

            public UserNameOrEmailAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
            {
            }

            protected UserNameOrEmailAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }
    }
}

