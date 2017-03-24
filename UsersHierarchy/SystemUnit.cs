using System;

namespace UsersHierarchy
{
    class SystemUnit
    {
        // _FIELDS_

        /// <summary>
        /// Sustem Unit keeps instances of currentUser, authorizator and commandPrompt
        /// </summary>
        public User currentUser;
        public Authorizator authorizator_instance;
        public CommandPrompt commandPrompt;






        // _CONSTRUCTOR_

        public SystemUnit()
        {
            this.currentUser = null;
            this.authorizator_instance = new Authorizator();
            this.InitializeUsers();
            this.commandPrompt = new CommandPrompt();
        }




        // _METHODS_
        
        /// <summary>
        /// Initialize users of system
        /// </summary>
        /// 
        public void InitializeUsers()
        {
            authorizator_instance.listOfAllUsers.Add(new User("guest"));
            authorizator_instance.listOfAllUsers.Add(new Editor("editor", "editor"));
            authorizator_instance.listOfAllUsers.Add(new Admin("admin", "admin", "key"));
        }



        /// <summary>
        /// Run Session of System unit by login authorized user and running CommandPrompt, on logout (EXIT command) prints all access attempts
        /// </summary>
        /// 
        public void RunSession()
        {
            while(true)
            {
                currentUser = authorizator_instance.getVerifiedUser();
                if ( null != currentUser)
                {
                    this.commandPrompt.Run(currentUser);
                    authorizator_instance.OutputAccessAttemptsList();
                    currentUser = null;
                }
            }
        }
    }
}
