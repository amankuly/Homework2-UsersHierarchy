using System;
using System.Collections.Generic;

namespace UsersHierarchy
{

    public class Authorizator
    {
        // _NESTED TYPES_

        /// <summary>
        /// Defining AccessAttempt type to store unit information(time, user, role) about all login attempts to system
        /// </summary>
        /// 
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





        // _FIELDS_

        /// <summary>
        /// Stores list of system access attempts
        /// </summary>
        /// 
        public List<AccessAttempt> listOfAccessAttempts;


        /// <summary>
        /// Stores list of defined users
        /// </summary>
        /// 
        public List<User> listOfAllUsers;
 





        // _CONSTRUCTOR_

        public Authorizator()
        {
            listOfAllUsers = new List<User>();
            listOfAccessAttempts = new List<AccessAttempt>();
        }





        // _METHODS_

        /// <summary>
        /// Verifies input credentials
        /// Returns valid user if verified, and returns null if password is wrong
        /// Record in Access Attempts list
        /// </summary>
        /// <returns></returns>
        /// 
        public User getVerifiedUser()
        {
            Console.Write("\nEnter username : ");
            string username = Console.ReadLine();
            User definedUser = getUserByName(username);
            if (null != definedUser)
            {
                UpdateAccessAttemptsList(new AccessAttempt(DateTime.Now, username, definedUser.role));
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
                UpdateAccessAttemptsList(new AccessAttempt(DateTime.Now, username, newBasicUser.role));
                return newBasicUser;
            }

        }



        /// <summary>
        /// get user by name
        /// </summary>
        /// <param name="username"></param>
        /// <returns>user from the list</returns>
        /// 
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


        

        /// <summary>
        /// Updates Access Attempts list
        /// </summary>
        /// <param name="attempt"></param>
        /// 
        public void UpdateAccessAttemptsList(AccessAttempt attempt)
        {
            this.listOfAccessAttempts.Add(attempt);
        }



        /// <summary>
        /// Outputs Access Attempts list
        /// </summary>
        /// 
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
