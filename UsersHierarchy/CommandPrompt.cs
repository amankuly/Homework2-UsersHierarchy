using System;


namespace UsersHierarchy
{
    class CommandPrompt
    {
        // _NESTED TYPES_

        /// <summary> 
        /// Define type Command to store (CommandName, arguments) pair
        /// </summary>
        /// 
        public struct Command
        {
            public enum CommandName
            {
                PRINT,
                EXIT,
                INVALID,
            };

            public string arguments;
            public CommandName commandName;
        }






        // _FIELDS_

        /// <summary>
        /// store currentUser and current command in Command prompt
        /// currentUser is needed for the Role knowledge, there can be a commands that depends on Roles
        /// </summary>
        /// 
        public User currentUser;
        public Command command;






        // _CONSTRUCTOR_

        public CommandPrompt()
        {
            this.currentUser = null;
        }





        // _METHODS_

        /// <summary>
        /// Parsing given string into command
        /// </summary>
        /// <param name="commandLine"></param>
        /// <returns>Command</returns>
        /// 
        public Command Parse( string commandLine)
        {
            Command cmd;
            if ( commandLine.StartsWith("PRINT") )
            {
                cmd.commandName = Command.CommandName.PRINT;
                cmd.arguments = commandLine.Substring(6);
            }
            else if ( commandLine.StartsWith("EXIT") )
            {
                cmd.commandName = Command.CommandName.EXIT;
                cmd.arguments = "";
            }
            else
            {
                cmd.commandName = Command.CommandName.INVALID;
                cmd.arguments = "Invalid Command";
            }
            return cmd;
        }



        /// <summary>
        /// Run Command Prompt for the given user
        /// </summary>
        /// <param name="currentUser"></param>
        /// 
        public void Run(User currentUser)
        {
            this.currentUser = currentUser;
            this.currentUser.WriteUserInfoToConsole();

            bool IsWorking = true;
            while(IsWorking)
            {
                Console.Write("{0}-->", currentUser.username);
                this.command = Parse(Console.ReadLine());
                switch ( this.command.commandName ) 
                {
                    case Command.CommandName.EXIT:
                        IsWorking = false;
                        break;

                    default:
                        Console.WriteLine("{0}-->{1}", currentUser.username, this.command.arguments);
                        break;
                }
            }
            this.currentUser = null; // optional
        }

    }
}