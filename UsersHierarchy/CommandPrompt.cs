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
                EXIT,
                INVALID,
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