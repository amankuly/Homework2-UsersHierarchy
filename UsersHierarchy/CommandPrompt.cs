using System;


namespace UsersHierarchy
{
    class CommandPrompt
    {
        //NESTED TYPES
        public struct Command
        {
            public enum CommandName
            {
                PRINT,
                EXIT
            };

            public string arguments;
            public CommandName commandName;
        }

        //FIELDS
        public User currentUser;
        public Command command;

        //CONSTRUCTOR
        public CommandPrompt()
        {
            this.currentUser = null;
        }

        public Command Parse( string commandLine)
        {
            Command cmd;
            if ( commandLine.StartsWith("PRINT") )
                cmd.commandName = Command.CommandName.PRINT;
        }

        public int Run(User currentUser)
        {
            this.currentUser = currentUser;
            this.currentUser.WriteUserInfoToConsole();
            while(true)
            {

            }
        }
        

    }
}
