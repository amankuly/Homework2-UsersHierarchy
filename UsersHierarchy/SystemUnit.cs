using System;

namespace UsersHierarchy
{
    class SystemUnit
    {
        //FIELDS
        public User currentUser;
        public Authorizator authorizator_instance;
        public CommandPrompt commandPrompt;

        //CONSTRUCTOR
        public SystemUnit()
        {
            this.currentUser = null;
            this.authorizator_instance = new Authorizator();
            this.InitializeUsers();
            this.commandPrompt = new CommandPrompt();
        }

        //INITIALIZE USERS OF SYSTEM
        
        public void InitializeUsers()
        {
            authorizator_instance.listOfAllUsers.Add(new User("guest"));
            authorizator_instance.listOfAllUsers.Add(new Editor("editor", "editor"));
            authorizator_instance.listOfAllUsers.Add(new Admin("admin", "admin", "key"));
        }

        public void RunSession()
        {
            while(true)
            {
                currentUser = authorizator_instance.getVerifiedUser();
                if ( null != currentUser)
                {
                    this.commandPrompt.Run(currentUser);
                    currentUser = null;
                }
            }
        }
    }
}
