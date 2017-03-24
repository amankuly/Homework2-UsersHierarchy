using System;
using System.Collections.Generic;

namespace UsersHierarchy
{

    public class Authorizator
    {
        public struct AccessAttempt
        {
            public DateTime    time;
            public string      user;
            public string      role;

            public AccessAttempt(DateTime time, string user, string role)
            {
                this.time = time;
                this.user = user;
                this.role = role;
            }
        }

        public List<AccessAttempt> listOfAccessAttempts;

        public List<User> listOfAllUsers;
        // public void AddUser(User new_user) // not neccessary for now, there is a public access to list

        public Authorizator()
        {
            listOfAllUsers = new List<User>();
            listOfAccessAttempts = new List<AccessAttempt>();
        }

        public User getUserByName(string username)
        {
            for (var i = 0; i < listOfAllUsers.Count; ++i)
            {
                if(listOfAllUsers[i].username == username)
                {
                    return this.listOfAllUsers[i];
                }
            }
            return null;
        }

        public User getVerifiedUser()
        {
            Console.WriteLine("\nEnter username :");
            string username = Console.ReadLine();
            User definedUser = getUserByName(username);
            if (null != definedUser)
            {
                UpdateAccessAttemptsList(new AccessAttempt(DateTime.Now, username, definedUser.role ));
                if (definedUser.CredentialsFromConsoleAreVerified())
                {
                    
                    return definedUser;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                User newBasicUser = new User(username);
                UpdateAccessAttemptsList(new AccessAttempt(DateTime.Now, username, newBasicUser.role ));
                return newBasicUser;
            }

        }

        public void UpdateAccessAttemptsList(AccessAttempt attempt)
        {
            this.listOfAccessAttempts.Add(attempt);
        }


        public void OutputAccessAttemptsList()
        {
            Console.WriteLine("\nSystem access attempts");
            foreach ( var attempt in this.listOfAccessAttempts)
            {
                Console.WriteLine("{0}: USER {1}\tROLE {2}", attempt.time, attempt.user, attempt.role);
            }
        }

    }
}
